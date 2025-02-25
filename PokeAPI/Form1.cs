using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Newtonsoft.Json;

namespace PokeAPI
{
    public partial class Form1 : XtraForm
    {
        private readonly Dictionary<string, Image> imageCache = new Dictionary<string, Image>();
        private BindingList<Pokemon> pokemonBindingList;

        public Form1()
        {
            InitializeComponent();
            SetupUI();
            LoadPokemonData();
        }
        private void SetupUI()
        {
            pokemonBindingList = new BindingList<Pokemon>();
            gridView.Columns.Clear();
            gridView.OptionsBehavior.AutoPopulateColumns = false;

            // Define columns
            GridColumn colId = new GridColumn { Caption = "ID", FieldName = "Id", Visible = true, Width = 50 };
            GridColumn colName = new GridColumn { Caption = "Name", FieldName = "Name", Visible = true, Width = 100 };
            GridColumn colFrontSprite = new GridColumn { Caption = "Front", FieldName = "FrontSprite", Visible = true, Width = 64 };
            GridColumn colBackSprite = new GridColumn { Caption = "Back", FieldName = "BackSprite", Visible = true, Width = 64 };
            GridColumn colShinySprite = new GridColumn { Caption = "Shiny", FieldName = "ShinySprite", Visible = true, Width = 64 };

            // Create RepositoryItemPictureEdit for actual image display
            RepositoryItemImageEdit pictureEdit = new RepositoryItemImageEdit
            {
                PopupFormSize = new Size(200, 200),
                ShowPopupShadow = true
            };

            gridControl.RepositoryItems.Add(pictureEdit);

            // Apply PictureEdit to sprite columns
            colFrontSprite.ColumnEdit = pictureEdit;
            colBackSprite.ColumnEdit = pictureEdit;
            colShinySprite.ColumnEdit = pictureEdit;

            // Add columns to GridView
            gridView.Columns.AddRange(new[] { colId, colName, colFrontSprite, colBackSprite, colShinySprite });

            gridControl.DataSource = pokemonBindingList;
        }
        private async void LoadPokemonData()
        {
            try
            {
                await FetchAllPokemonData();
                Text = $"Pokémon Loaded: {pokemonBindingList.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Pokémon data: {ex.Message}");
            }
        }
        private async Task FetchAllPokemonData()
        {
            using (var client = new HttpClient())
            {
                string baseUrl = "https://pokeapi.co/api/v2/pokemon";
                string nextUrl = baseUrl + "?limit=100";
                int totalPokemon = 0;
                int loadedPokemon = 0;

                var initialResponse = await client.GetStringAsync(baseUrl + "?limit=1");
                var initialData = JsonConvert.DeserializeObject<PokemonListResponse>(initialResponse);
                totalPokemon = initialData.Count;
                repositoryItemProgressBar1.Maximum = totalPokemon;

                while (!string.IsNullOrEmpty(nextUrl))
                {
                    var response = await client.GetStringAsync(nextUrl);
                    var pokemonResponse = JsonConvert.DeserializeObject<PokemonListResponse>(response);

                    var tasks = pokemonResponse.Results.Select(async result =>
                    {
                        var detailsResponse = await client.GetStringAsync(result.Url);
                        var details = JsonConvert.DeserializeObject<PokemonDetails>(detailsResponse);

                        var frontSprite = await LoadImageFromUrl(details.Sprites.FrontDefault);
                        var backSprite = await LoadImageFromUrl(details.Sprites.BackDefault);
                        var shinySprite = await LoadImageFromUrl(details.Sprites.FrontShiny);

                        var pokemon = new Pokemon
                        {
                            Id = details.Id,
                            Name = details.Name,
                            FrontSprite = frontSprite,
                            BackSprite = backSprite,
                            ShinySprite = shinySprite
                        };

                        Invoke((Action)(() =>
                        {
                            pokemonBindingList.Add(pokemon);
                            loadedPokemon++;
                            barEditItem1.EditValue = loadedPokemon;
                            progressLabel.Caption = $"Loading Pokémon: {loadedPokemon}/{totalPokemon} ({(loadedPokemon * 100 / totalPokemon)}%)";
                        }));

                        return details;
                    });

                    await Task.WhenAll(tasks);
                    nextUrl = pokemonResponse.Next;
                }
            }
        }
        private async Task<Image> LoadImageFromUrl(string url)
        {
            try
            {
                if (string.IsNullOrEmpty(url)) return new Bitmap(1, 1);

                if (imageCache.ContainsKey(url))
                {
                    return imageCache[url];
                }

                using (var client = new HttpClient())
                {
                    var bytes = await client.GetByteArrayAsync(url);
                    using (var stream = new System.IO.MemoryStream(bytes))
                    {
                        var image = Image.FromStream(stream);
                        imageCache[url] = image;
                        return image;
                    }
                }
            }
            catch (Exception)
            {
                return new Bitmap(1, 1);
            }
        }
    }

    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Image FrontSprite { get; set; }
        public Image BackSprite { get; set; }
        public Image ShinySprite { get; set; }
    }
    public class PokemonListResponse
    {
        public List<PokemonResult> Results { get; set; }
        public string Next { get; set; }
        public int Count { get; set; }
    }
    public class PokemonResult
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
    public class PokemonDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Sprites Sprites { get; set; }
    }
    public class Sprites
    {
        [JsonProperty("front_default")]
        public string FrontDefault { get; set; }

        [JsonProperty("back_default")]
        public string BackDefault { get; set; }

        [JsonProperty("front_shiny")]
        public string FrontShiny { get; set; }
    }
}