using System.Windows.Forms;

namespace WinFormsApp9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            toolTip.SetToolTip(AddEventBTN, "Добавить новое событие");
            toolTip.SetToolTip(DeleteEventBTN, "Удалить выбранное событие");
            toolTip.SetToolTip(CheckEventBTN, "Отметить выбранное событие как выполненное");
        }
        private void Form1_Load(object sender, EventArgs e)
        { }
        private void EventDate_ValueChanged(object sender, EventArgs e)
        { }
        private void EventNameTextBox_TextChanged(object sender, EventArgs e)
        { }
        private void progressBar_Click(object sender, EventArgs e)
        { }
        private void EventListBox_SelectedIndexChanged(object sender, EventArgs e)
        { }
        private void UpdateProgressBar()
        {
            int total = EventListBox.Items.Count;
            int complete = 0;
            foreach (var item in EventListBox.Items)
            {
                if (item.ToString().Contains("[Выполнено]"))
                {
                    complete++;
                }
            }
            progressBar.Value = total > 0 ? (complete * 100) / total : 0;
        }

        private void AddEventBTN_Click_1(object sender, EventArgs e)
        {
            string name = EventNameTextBox.Text;
            DateTime date = EventDate.Value;

            if (!string.IsNullOrWhiteSpace(name))
            {
                EventListBox.Items.Add($"{date.ToShortDateString()} - {name}");
                EventNameTextBox.Clear();
                UpdateProgressBar();
            }
            else
            {
                MessageBox.Show("Введите название события.");
            }
        }

        private void DeleteEventBTN_Click_1(object sender, EventArgs e)
        {
            if (EventListBox.SelectedItem != null)
            {
                EventListBox.Items.Remove(EventListBox.SelectedItem);
                UpdateProgressBar();
            }
            else
            {
                MessageBox.Show("Выберите событие для удаления.");
            }
        }

        private void CheckEventBTN_Click_1(object sender, EventArgs e)
        {
            if (EventListBox.SelectedItem != null)
            {
                int index = EventListBox.SelectedIndex;
                string select = EventListBox.SelectedItem.ToString();

                if (!select.Contains("[Выполнено]"))
                {
                    EventListBox.Items[index] = "[Выполнено] " + select;
                    UpdateProgressBar();
                }
                else
                {
                    MessageBox.Show("Событие уже отмечено как выполненное.");
                }
            }
            else
            {
                MessageBox.Show("Выберите событие для отметки как выполненное.");
            }
        }
    }
}