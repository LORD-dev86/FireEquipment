using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Npgsql;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace FireEquipment2
{
    public static class Respondent
    {
        public static void PrintEqDocument(int department, DataGridView dataGridView)
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd");
            var name = "Оборудование_" + department + "_" + date + ".pdf";
            var path = $"F:\\{name}";

            var writer = new PdfWriter(path);
            var pdf = new PdfDocument(writer);
            var font = PdfFontFactory.CreateFont("../../arial.ttf", "cp1251");
            Document document = new Document(pdf, new PageSize
                (PageSize.A4.GetWidth(), PageSize.A4.GetHeight()).Rotate());
            document.SetFont(font);

            Paragraph header =
                 new Paragraph($"Отчёт об используемых СПЗ, " +
                 $"подразделение №{department}")
             .SetTextAlignment(TextAlignment.CENTER)
             .SetFontSize(14);

            document.Add(header);

            float[] columnWidth = { 3, 4, 5, 6, 5, 5, 5, 5, 5, 6, 6, 4};
            document.Add(PDFTableFromDGV(dataGridView, columnWidth));

            Paragraph paragraph = new Paragraph($"Отчёт сформирован\t{DateTime.Now}");
            document.Add(paragraph);

            paragraph = new Paragraph($"Ответственный от подразделения №{department}\t\t_____________/_____________");
            document.Add(paragraph);

            document.Close();

            UpdateEqDocPath(path, department);

            Process process = new Process();
            process.StartInfo.FileName = path;
            process.StartInfo.Verb = "open";
            process.Start();
        }
        public static void PrintCheckDocument(int department, DataGridView dataGridView)
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd");
            var name = "Проверки_" + department + "_" + date + ".pdf";
            var path = $"F:\\{name}";

            var writer = new PdfWriter(path);
            var pdf = new PdfDocument(writer);
            var font = PdfFontFactory.CreateFont("F:\\arial.ttf", "cp1251");

            Document document = new Document(pdf, PageSize.A4);
            document.SetFont(font);

            Paragraph header =
                 new Paragraph($"Отчёт о проведенных проверках, подразделение №{department}")
             .SetTextAlignment(TextAlignment.CENTER)
             .SetFontSize(14);

            document.Add(header);

            float[] columnWidth = { 3, 4, 5, 5, 5, 5 };
            document.Add(PDFTableFromDGV(dataGridView, columnWidth));

            Paragraph paragraph = new Paragraph($"Отчёт сформирован\t{DateTime.Now}");
            document.Add(paragraph);

            paragraph = new Paragraph($"Ответственный от подразделения №{department}\t\t_____________/_____________");
            document.Add(paragraph);

            document.Close();

            UpdateChDocPath(path, department);

            Process process = new Process();
            process.StartInfo.FileName = path;
            process.StartInfo.Verb = "open";
            process.Start();
        }

        private static void UpdateChDocPath(string filepath, int department)
        {
            try
            {
                SqlQuery.conn.Open();
                SqlQuery.sql = @"UPDATE department SET dp_chdoc = 
                                :_filepath WHERE dp_id = :_department";

                SqlQuery.cmd = new NpgsqlCommand(SqlQuery.sql, SqlQuery.conn);
                SqlQuery.cmd.Parameters.AddWithValue
                    ("_filepath", filepath);
                SqlQuery.cmd.Parameters.AddWithValue
                    ("_department", department);
                
                SqlQuery.cmd.ExecuteReader();
                SqlQuery.conn.Close();
            }
            catch (Exception ex)
            {
                SqlQuery.conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private static void UpdateEqDocPath(string filepath, int department)
        {
            try
            {
                SqlQuery.conn.Open();
                SqlQuery.sql = @"UPDATE department SET dp_eqdoc = 
                                :_filepath WHERE dp_id = :_department";

                SqlQuery.cmd = new NpgsqlCommand(SqlQuery.sql, SqlQuery.conn);
                SqlQuery.cmd.Parameters.AddWithValue
                    ("_filepath", filepath);
                SqlQuery.cmd.Parameters.AddWithValue
                    ("_department", department);

                SqlQuery.cmd.ExecuteReader();
                SqlQuery.conn.Close();
            }
            catch (Exception ex)
            {
                SqlQuery.conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private static Table PDFTableFromDGV(DataGridView dgv, float[] columnWidths)
        {
            int dgvRowCount = dgv.Rows.Count;
            int dgvColumnCount = dgv.Columns.Count;

            Table table = new Table(columnWidths);
            table.SetWidth(UnitValue.CreatePercentValue(100));

            for (int i = 0; i < dgvColumnCount; i++)
            {
                Cell headerCell = new Cell()
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(10);
                var paragraph = new Paragraph(dgv.Columns[i].HeaderText);
                headerCell.Add(paragraph);
                table.AddHeaderCell(headerCell);
            }

            for (int i = 0; i < dgvRowCount; i++)
            {
                for (int c = 0; c < dgvColumnCount; c++)
                {
                    Cell cell = new Cell()
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFontSize(10);

                    if (dgv.Columns[c].ValueType == typeof(DateTime))
                    {
                        string dateFormat = "dd.MM.yyyy";
                        var dateValue = (DateTime)dgv.Rows[i].Cells[c].Value;
                        var formattedDate = dateValue.ToString(dateFormat);
                        var paragraph = new Paragraph(formattedDate);
                        cell.Add(paragraph);
                    }
                    else if (dgv.Columns[c].ValueType == typeof(bool))
                    {
                        bool boolValue = (bool)dgv.Rows[i].Cells[c].Value;
                        var paragraph = new Paragraph(boolValue ? "Да" : "Нет");
                        cell.Add(paragraph);
                    }
                    else
                    {
                        var paragraph = new Paragraph(dgv.Rows[i].Cells[c].Value.ToString());
                        cell.Add(paragraph);
                    }

                    table.AddCell(cell);
                }
            }

            return table;
        }


    }
}
