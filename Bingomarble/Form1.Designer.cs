namespace Bingomarble
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonDice = new System.Windows.Forms.Button();
            this.textBoxDice = new System.Windows.Forms.TextBox();
            this.textBoxP1_Location = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBoxP2_Location = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxP1_Money = new System.Windows.Forms.TextBox();
            this.textBoxP2_Money = new System.Windows.Forms.TextBox();
            this.textBoxInformation = new System.Windows.Forms.TextBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonUpgrade = new System.Windows.Forms.Button();
            this.textBoxTurn = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonDice
            // 
            this.buttonDice.Location = new System.Drawing.Point(1221, 178);
            this.buttonDice.Margin = new System.Windows.Forms.Padding(7);
            this.buttonDice.Name = "buttonDice";
            this.buttonDice.Size = new System.Drawing.Size(206, 76);
            this.buttonDice.TabIndex = 1;
            this.buttonDice.Text = "주사위 굴리기";
            this.buttonDice.UseVisualStyleBackColor = true;
            this.buttonDice.Click += new System.EventHandler(this.buttonDice_Click);
            // 
            // textBoxDice
            // 
            this.textBoxDice.Location = new System.Drawing.Point(1528, 212);
            this.textBoxDice.Margin = new System.Windows.Forms.Padding(7);
            this.textBoxDice.Name = "textBoxDice";
            this.textBoxDice.ReadOnly = true;
            this.textBoxDice.Size = new System.Drawing.Size(223, 39);
            this.textBoxDice.TabIndex = 2;
            this.textBoxDice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxP1_Location
            // 
            this.textBoxP1_Location.Location = new System.Drawing.Point(1221, 323);
            this.textBoxP1_Location.Margin = new System.Windows.Forms.Padding(7);
            this.textBoxP1_Location.Name = "textBoxP1_Location";
            this.textBoxP1_Location.ReadOnly = true;
            this.textBoxP1_Location.Size = new System.Drawing.Size(223, 39);
            this.textBoxP1_Location.TabIndex = 3;
            this.textBoxP1_Location.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(30, 29);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(11, 11, 11, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 15;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 15;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1147, 1130);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // textBoxP2_Location
            // 
            this.textBoxP2_Location.Location = new System.Drawing.Point(1528, 321);
            this.textBoxP2_Location.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxP2_Location.Name = "textBoxP2_Location";
            this.textBoxP2_Location.ReadOnly = true;
            this.textBoxP2_Location.Size = new System.Drawing.Size(223, 39);
            this.textBoxP2_Location.TabIndex = 4;
            this.textBoxP2_Location.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1524, 178);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 27);
            this.label1.TabIndex = 5;
            this.label1.Text = "주사위 번호";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1217, 289);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 27);
            this.label2.TabIndex = 6;
            this.label2.Text = "P1 위치";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1523, 292);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 27);
            this.label3.TabIndex = 7;
            this.label3.Text = "P2 위치";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1217, 400);
            this.label4.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 27);
            this.label4.TabIndex = 8;
            this.label4.Text = "P1 돈";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1523, 400);
            this.label5.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 27);
            this.label5.TabIndex = 9;
            this.label5.Text = "P2 돈";
            // 
            // textBoxP1_Money
            // 
            this.textBoxP1_Money.Location = new System.Drawing.Point(1221, 434);
            this.textBoxP1_Money.Margin = new System.Windows.Forms.Padding(7);
            this.textBoxP1_Money.Name = "textBoxP1_Money";
            this.textBoxP1_Money.ReadOnly = true;
            this.textBoxP1_Money.Size = new System.Drawing.Size(223, 39);
            this.textBoxP1_Money.TabIndex = 10;
            this.textBoxP1_Money.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxP2_Money
            // 
            this.textBoxP2_Money.Location = new System.Drawing.Point(1528, 434);
            this.textBoxP2_Money.Margin = new System.Windows.Forms.Padding(7);
            this.textBoxP2_Money.Name = "textBoxP2_Money";
            this.textBoxP2_Money.ReadOnly = true;
            this.textBoxP2_Money.Size = new System.Drawing.Size(223, 39);
            this.textBoxP2_Money.TabIndex = 11;
            this.textBoxP2_Money.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxInformation
            // 
            this.textBoxInformation.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBoxInformation.Location = new System.Drawing.Point(1221, 644);
            this.textBoxInformation.Margin = new System.Windows.Forms.Padding(7);
            this.textBoxInformation.Multiline = true;
            this.textBoxInformation.Name = "textBoxInformation";
            this.textBoxInformation.ReadOnly = true;
            this.textBoxInformation.Size = new System.Drawing.Size(530, 515);
            this.textBoxInformation.TabIndex = 12;
            this.textBoxInformation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(1529, 524);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(222, 74);
            this.buttonClose.TabIndex = 13;
            this.buttonClose.Text = "게임 마치기";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonUpgrade
            // 
            this.buttonUpgrade.Location = new System.Drawing.Point(1222, 524);
            this.buttonUpgrade.Name = "buttonUpgrade";
            this.buttonUpgrade.Size = new System.Drawing.Size(223, 74);
            this.buttonUpgrade.TabIndex = 14;
            this.buttonUpgrade.Text = "업그레이드";
            this.buttonUpgrade.UseVisualStyleBackColor = true;
            this.buttonUpgrade.Click += new System.EventHandler(this.buttonUpgrade_Click);
            // 
            // textBoxTurn
            // 
            this.textBoxTurn.BackColor = System.Drawing.Color.Yellow;
            this.textBoxTurn.Font = new System.Drawing.Font("Gulim", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBoxTurn.Location = new System.Drawing.Point(1406, 52);
            this.textBoxTurn.Name = "textBoxTurn";
            this.textBoxTurn.ReadOnly = true;
            this.textBoxTurn.Size = new System.Drawing.Size(146, 76);
            this.textBoxTurn.TabIndex = 15;
            this.textBoxTurn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(1232, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 42);
            this.label6.TabIndex = 16;
            this.label6.Text = "순서 : ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2328, 1336);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxTurn);
            this.Controls.Add(this.buttonUpgrade);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.textBoxInformation);
            this.Controls.Add(this.textBoxP2_Money);
            this.Controls.Add(this.textBoxP1_Money);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxP2_Location);
            this.Controls.Add(this.textBoxP1_Location);
            this.Controls.Add(this.textBoxDice);
            this.Controls.Add(this.buttonDice);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonDice;
        private System.Windows.Forms.TextBox textBoxDice;
        private System.Windows.Forms.TextBox textBoxP1_Location;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBoxP2_Location;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxP1_Money;
        private System.Windows.Forms.TextBox textBoxP2_Money;
        private System.Windows.Forms.TextBox textBoxInformation;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonUpgrade;
        private System.Windows.Forms.TextBox textBoxTurn;
        private System.Windows.Forms.Label label6;
    }
}

