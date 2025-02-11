﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Resturant_POS.Model
{
    public partial class frmTableAdd : SampleAdd
    {
        public frmTableAdd()
        {
            InitializeComponent();
        }

        public int id = 0;

        public override void btnSave_Click(object sender, EventArgs e)
        {
            string qry = "";
            Hashtable ht = new Hashtable();

            if (id == 0)
            {
                qry = "INSERT INTO tables (tName) VALUES (:Name)";
                ht.Add(":Name", txtName.Text);
            }
            else
            {
                qry = "UPDATE tables SET tName = :Name WHERE tID = :id";
                ht.Add(":Name", txtName.Text);
                ht.Add(":id", id);
            }

            if (mainClass.Oracle(qry, ht) > 0)
            {
                MessageBox.Show("Saved Successfully");
                id = 0;
                txtName.Text = "";
                txtName.Focus();
            }
        }
    }
}
