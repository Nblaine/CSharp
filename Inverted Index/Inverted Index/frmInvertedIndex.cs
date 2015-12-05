using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Inverted_Index
{
    public partial class frmInvertedIndex : Form
    {
        private string[] DefaultStopWords = { "a", "and", "for", "from", "in", "is", "it", "not", "on", "one", "the", "to", "but", "or", "by", "do", "of", "like", "some", "many", "an", "many" };

        private void ResetStopWords()
        {
            lstStopWords.Items.Clear();

            foreach (string sWord in DefaultStopWords)
                lstStopWords.Items.Add(sWord);
        }

        public frmInvertedIndex()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetStopWords();
        }

        private void frmInvertedIndex_Load(object sender, EventArgs e)
        {
            ResetStopWords();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            for (int i = lstStopWords.SelectedIndices.Count - 1; i >= 0; i--)
            {
                int index = lstStopWords.SelectedIndices[i];
                lstStopWords.Items.RemoveAt(index);
            }
        }

        private void btnAddRange_Click(object sender, EventArgs e)
        {
            string[] sWordRange = txtStopWord.Text.Trim().Split(',');

            foreach (string s in sWordRange)
                lstStopWords.Items.Add(s.Trim());
        }

        private void btnRunSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a reference to the current directory.
                DirectoryInfo di = new DirectoryInfo(Application.StartupPath + "/Text");
                // Create an array representing all .aspx files in the current directory.
                FileInfo[] fi = di.GetFiles("*.txt", SearchOption.AllDirectories);

                //lstStopWords.Items.Clear();

                Dictionary<string, string[]> dicTextFiles = new Dictionary<string, string[]>();

                foreach (FileInfo fiTemp in fi)
                {
                    StreamReader sr = fiTemp.OpenText();
                    string sRawText = sr.ReadToEnd();

                    //string sFormattedText = sRawText.Replace(",", string.Empty).Replace(".", string.Empty).Replace("'", string.Empty).Replace("?", string.Empty).Replace(";", string.Empty);
                    string sFormattedText = string.Empty;

                    StringBuilder sb = new StringBuilder();
                    //0A
                    foreach (char c in sRawText)
                        if (Convert.ToInt32(c) != Convert.ToInt32("0A", 16) && Convert.ToInt32(c) != Convert.ToInt32("0D", 16)
                            && Convert.ToInt32(c) != Convert.ToInt32("09", 16) && Convert.ToInt32(c) != Convert.ToInt32("0B", 16)
                            && (Char.IsWhiteSpace(c) || Char.IsLetterOrDigit(c)))
                            sb.Append(c);

                    sFormattedText = sb.ToString().ToLower();

                    string[] sRawTokenizedText = sFormattedText.Split(' ');

                    List<string> lstCleanedTokens = new List<string>();

                    foreach (string s in sRawTokenizedText)
                    {
                        if (s.Trim() != string.Empty && !lstStopWords.Items.Contains(s) && !lstCleanedTokens.Contains(s))
                        {
                            lstCleanedTokens.Add(s);
                        }
                    }

                    lstCleanedTokens.Sort();

                    dicTextFiles.Add(fiTemp.Name, lstCleanedTokens.ToArray<string>());
                }//foreach (FileInfo fiTemp in fi)

                DataTable dtWords = new DataTable();
                dtWords.Columns.AddRange
                (
                    new DataColumn[]
                    {
                        new DataColumn("ID", typeof(string)),
                        new DataColumn("Index", typeof(int)),
                        new DataColumn("Word", typeof(string)),
                        new DataColumn("FileName", typeof(string))
                    }
                );
                int iWordID = 0;



                foreach (KeyValuePair<string, string[]> kvp in dicTextFiles)
                {
                    string[] sCurrentArray = kvp.Value;
                    foreach (string s in sCurrentArray)
                    {
                        DataRow dr = dtWords.NewRow();

                        dr["ID"] = kvp.Key + ":" + iWordID.ToString();
                        dr["Index"] = iWordID;
                        dr["Word"] = s;
                        dr["FileName"] = kvp.Key;

                        dtWords.Rows.Add(dr);

                        iWordID++;
                    }

                    iWordID = 0;
                }

                dgvWords.DataSource = dtWords;

                string[] sRawSearchTokens = txtSearch.Text.Trim().Split(' '),
                         sCleanedSearchTokens = { };

                List<string> lstCleanedSearchTokens = new List<string>();

                foreach(string s in sRawSearchTokens)
                {
                    if (s.Trim() != string.Empty && !lstStopWords.Items.Contains(s))
                    {
                        StringBuilder sbCleanedSearch = new StringBuilder();
                        foreach (char c in s)
                        {
                            if (!Char.IsPunctuation(c))
                                sbCleanedSearch.Append(c);
                        }

                        lstCleanedSearchTokens.Add(sbCleanedSearch.ToString());
                        sbCleanedSearch = null;
                    }
                    else
                        continue;
                }

                sCleanedSearchTokens = lstCleanedSearchTokens.ToArray<string>();

                List<DataRow[]> lstResults = new List<DataRow[]>();


                foreach(string sSearchToken in sCleanedSearchTokens)
                {
                    DataRow[] drSearched = dtWords.Select("Word = '" + sSearchToken + "'");

                    if(drSearched.Length > 0)
                    {
                        lstResults.Add(drSearched);
                    }
                }

                lstResultsDisplay.Items.Clear();

                if(lstResults.Count > 0)
                {
                    foreach(DataRow[] drResultArray in lstResults)
                    {
                        foreach(DataRow drResult in drResultArray)
                        {
                            string sDisplay = "ID: " + drResult["ID"].ToString() + ", Word: " + drResult["Word"].ToString() + ", Index = " + drResult["Index"].ToString() + ", File Name: " + drResult["FileName"].ToString();

                            lstResultsDisplay.Items.Add(sDisplay);
                        }//foreach(DataRow drResult in drResultArray)
                    }//foreach(DataRow[] drResultArray in lstResults)
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }

        }
    }
}
