namespace Main
{
    partial class Main
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
            this.btnEmployee = new System.Windows.Forms.Button();
            this.btnContact = new System.Windows.Forms.Button();
            this.btnSalary = new System.Windows.Forms.Button();
            this.btnAllowance = new System.Windows.Forms.Button();
            this.btnDepartment = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnEmployee
            // 
            this.btnEmployee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployee.Location = new System.Drawing.Point(85, 132);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(249, 102);
            this.btnEmployee.TabIndex = 0;
            this.btnEmployee.Text = "Add Employee";
            this.btnEmployee.UseVisualStyleBackColor = true;
            this.btnEmployee.Click += new System.EventHandler(this.btnEmployee_Click);
            // 
            // btnContact
            // 
            this.btnContact.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContact.Location = new System.Drawing.Point(424, 134);
            this.btnContact.Name = "btnContact";
            this.btnContact.Size = new System.Drawing.Size(249, 102);
            this.btnContact.TabIndex = 1;
            this.btnContact.Text = "Contact";
            this.btnContact.UseVisualStyleBackColor = true;
            this.btnContact.Click += new System.EventHandler(this.btnContact_Click);
            // 
            // btnSalary
            // 
            this.btnSalary.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalary.Location = new System.Drawing.Point(424, 267);
            this.btnSalary.Name = "btnSalary";
            this.btnSalary.Size = new System.Drawing.Size(249, 102);
            this.btnSalary.TabIndex = 2;
            this.btnSalary.Text = "Salary";
            this.btnSalary.UseVisualStyleBackColor = true;
            this.btnSalary.Click += new System.EventHandler(this.btnSalary_Click);
            // 
            // btnAllowance
            // 
            this.btnAllowance.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAllowance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAllowance.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAllowance.Location = new System.Drawing.Point(253, 404);
            this.btnAllowance.Name = "btnAllowance";
            this.btnAllowance.Size = new System.Drawing.Size(249, 102);
            this.btnAllowance.TabIndex = 3;
            this.btnAllowance.Text = "Allowance";
            this.btnAllowance.UseVisualStyleBackColor = true;
            this.btnAllowance.Click += new System.EventHandler(this.btnAllowance_Click);
            // 
            // btnDepartment
            // 
            this.btnDepartment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDepartment.Location = new System.Drawing.Point(85, 267);
            this.btnDepartment.Name = "btnDepartment";
            this.btnDepartment.Size = new System.Drawing.Size(249, 102);
            this.btnDepartment.TabIndex = 4;
            this.btnDepartment.Text = "Department";
            this.btnDepartment.UseVisualStyleBackColor = true;
            this.btnDepartment.Click += new System.EventHandler(this.btnDepartment_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Stencil", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(190, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(398, 47);
            this.label2.TabIndex = 6;
            this.label2.Text = "Employee Details";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(857, 518);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDepartment);
            this.Controls.Add(this.btnAllowance);
            this.Controls.Add(this.btnSalary);
            this.Controls.Add(this.btnContact);
            this.Controls.Add(this.btnEmployee);
            this.ForeColor = System.Drawing.Color.MidnightBlue;
            this.Name = "Main";
            this.Text = "Main Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEmployee;
        private System.Windows.Forms.Button btnContact;
        private System.Windows.Forms.Button btnSalary;
        private System.Windows.Forms.Button btnAllowance;
        private System.Windows.Forms.Button btnDepartment;
        private System.Windows.Forms.Label label2;
    }
}

