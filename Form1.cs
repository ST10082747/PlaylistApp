namespace PlaylistApp
{
    public partial class Form1 : Form
    {
        private DoublyLinkedList playlist;

        public Form1()
        {
            InitializeComponent();
            playlist = new DoublyLinkedList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string trackName = textBox1.Text;
            Track foundTrack = playlist.FindTrack(trackName);
            if (foundTrack != null)
            {
                MessageBox.Show($"Track found: {foundTrack.Name}", "Track Found");
            }
            else
            {
                MessageBox.Show("Track not found.", "Track Not Found");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Track nextTrack = playlist.GetNextTrack();
            if (nextTrack != null)
            {
                MessageBox.Show($"Playing next track: {nextTrack.Name}", "Next Track");
                HighlightCurrentTrack(nextTrack);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string trackName = textBox1.Text;
            if (!string.IsNullOrWhiteSpace(trackName))
            {
                playlist.RemoveTrack(trackName);
                RefreshTrackList();
                textBox1.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string trackName = textBox1.Text;
            if (!string.IsNullOrWhiteSpace(trackName))
            {
                playlist.AddTrack(trackName);
                RefreshTrackList();
                textBox1.Clear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Track previousTrack = playlist.GetPreviousTrack();
            if (previousTrack != null)
            {
                MessageBox.Show($"Playing previous track: {previousTrack.Name}", "Previous Track");
                HighlightCurrentTrack(previousTrack);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            playlist.Shuffle();
            RefreshTrackList();
        }

        private void HighlightCurrentTrack(Track currentTrack)
        {
            int index = playlist.GetAllTrackNames().IndexOf(currentTrack.Name);
            if (index != -1)
            {
                listBox1.SelectedIndex = index;
            }
        }

        private void RefreshTrackList()
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(playlist.GetAllTrackNames().ToArray());
        }
    }
}
