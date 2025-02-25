namespace PokeAPI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gridControl = new DevExpress.XtraGrid.GridControl();
            gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            skinRibbonGalleryBarItem = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            skinDropDownButtonItem = new DevExpress.XtraBars.SkinDropDownButtonItem();
            skinPaletteRibbonGalleryBarItem = new DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem();
            barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            progressLabel = new DevExpress.XtraBars.BarStaticItem();
            ribbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            rpgSkins = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)gridControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemProgressBar1).BeginInit();
            SuspendLayout();
            // 
            // gridControl
            // 
            gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            gridControl.Location = new System.Drawing.Point(0, 141);
            gridControl.MainView = gridView;
            gridControl.Name = "gridControl";
            gridControl.Size = new System.Drawing.Size(1082, 448);
            gridControl.TabIndex = 0;
            gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView });
            // 
            // gridView
            // 
            gridView.GridControl = gridControl;
            gridView.Name = "gridView";
            gridView.OptionsView.ShowFooter = true;
            // 
            // ribbonControl
            // 
            ribbonControl.ExpandCollapseItem.Id = 0;
            ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl.ExpandCollapseItem, skinRibbonGalleryBarItem, skinDropDownButtonItem, skinPaletteRibbonGalleryBarItem, barEditItem1, progressLabel });
            ribbonControl.Location = new System.Drawing.Point(0, 0);
            ribbonControl.MaxItemId = 5;
            ribbonControl.Name = "ribbonControl";
            ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage });
            ribbonControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemProgressBar1 });
            ribbonControl.Size = new System.Drawing.Size(1082, 141);
            ribbonControl.StatusBar = ribbonStatusBar1;
            // 
            // skinRibbonGalleryBarItem
            // 
            skinRibbonGalleryBarItem.Caption = "skinRibbonGalleryBarItem";
            skinRibbonGalleryBarItem.Id = 1;
            skinRibbonGalleryBarItem.Name = "skinRibbonGalleryBarItem";
            // 
            // skinDropDownButtonItem
            // 
            skinDropDownButtonItem.ActAsDropDown = true;
            skinDropDownButtonItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            skinDropDownButtonItem.Id = 2;
            skinDropDownButtonItem.Name = "skinDropDownButtonItem";
            // 
            // skinPaletteRibbonGalleryBarItem
            // 
            skinPaletteRibbonGalleryBarItem.Caption = "skinPaletteRibbonGalleryBarItem";
            skinPaletteRibbonGalleryBarItem.Id = 3;
            skinPaletteRibbonGalleryBarItem.Name = "skinPaletteRibbonGalleryBarItem";
            // 
            // barEditItem1
            // 
            barEditItem1.Caption = "Status:";
            barEditItem1.Edit = repositoryItemProgressBar1;
            barEditItem1.EditWidth = 100;
            barEditItem1.Id = 2;
            barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemProgressBar1
            // 
            repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
            repositoryItemProgressBar1.ShowTitle = true;
            // 
            // progressLabel
            // 
            progressLabel.Caption = "Loaded Pokemon:";
            progressLabel.Id = 4;
            progressLabel.Name = "progressLabel";
            // 
            // ribbonPage
            // 
            ribbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { rpgSkins });
            ribbonPage.Name = "ribbonPage";
            ribbonPage.Text = "ribbonPage";
            // 
            // rpgSkins
            // 
            rpgSkins.ItemLinks.Add(skinDropDownButtonItem);
            rpgSkins.ItemLinks.Add(skinPaletteRibbonGalleryBarItem);
            rpgSkins.Name = "rpgSkins";
            rpgSkins.Text = "Skins";
            // 
            // ribbonStatusBar1
            // 
            ribbonStatusBar1.ItemLinks.Add(barEditItem1);
            ribbonStatusBar1.ItemLinks.Add(progressLabel);
            ribbonStatusBar1.Location = new System.Drawing.Point(0, 589);
            ribbonStatusBar1.Name = "ribbonStatusBar1";
            ribbonStatusBar1.Ribbon = ribbonControl;
            ribbonStatusBar1.Size = new System.Drawing.Size(1082, 29);
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1082, 618);
            Controls.Add(gridControl);
            Controls.Add(ribbonStatusBar1);
            Controls.Add(ribbonControl);
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "PokeAPI";
            ((System.ComponentModel.ISupportInitialize)gridControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemProgressBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgSkins;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem;
        private DevExpress.XtraBars.SkinDropDownButtonItem skinDropDownButtonItem;
        private DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem skinPaletteRibbonGalleryBarItem;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
        private DevExpress.XtraBars.BarStaticItem progressLabel;
    }
}
