﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tyuiu.PomazDS.Sprint6.Task4.V1.Lib;

namespace Tyuiu.PomazDS.Sprint6.Task4.V1
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        DataService ds = new DataService();
        private void buttonDone_PDS_Click(object sender, EventArgs e)
        {
            try
            {
                int startValue = int.Parse(textBoxInputStartValue_PDS.Text);
                int stopValue = int.Parse(textBoxInputStopValue_PDS.Text);

                double[] array = ds.GetMassFunction(startValue, stopValue);

                chartFunction_PDS.ChartAreas[0].AxisX.Title = "Ось X";
                chartFunction_PDS.ChartAreas[0].AxisY.Title = "Ось Y";
                textBoxResult_PDS.Text = null;chartFunction_PDS.Series[0].Points.Clear();
                for (global::System.Int32 i = 0; i < array.Length; i++)
                {
                    chartFunction_PDS.Series[0].Points.AddXY(startValue, array[i]);
                    startValue++;
                    textBoxResult_PDS.AppendText(array[i].ToString());
                    textBoxResult_PDS.AppendText("\r\n");
                }

            }

            catch
            {
                MessageBox.Show("Неверный ввод данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_PDS_Click(object sender, EventArgs e)
        {
            string path = $@"{Directory.GetCurrentDirectory()}\OutPutFileTask4.txt";
            File.WriteAllText(path, textBoxResult_PDS.Text);

            DialogResult dr = MessageBox.Show("Файл " + path + " сохранён успешно!\nОткрыть его в блокноте?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

           if (dr == DialogResult.Yes)
            {
                System.Diagnostics.Process txt = new System.Diagnostics.Process();
                txt.StartInfo.FileName = "notepad.exe";
                txt.StartInfo.Arguments = path;
                txt.Start();
            }
        }

        private void buttonHelp_PDS_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Таск 4 Варинт 1 выполнил студент ИИПб-23-2 Помаз Дмитрий Сергеевич", "Информация о студенте", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
