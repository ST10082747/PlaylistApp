using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistApp
{
    public class DoublyLinkedList
    {
        private Track head;
        private Track tail;
        private Track current;

        public DoublyLinkedList()
        {
            head = null;
            tail = null;
            current = null;
        }

        public void AddTrack(string name)
        {
            Track newTrack = new Track(name);
            if (head == null)
            {
                head = newTrack;
                tail = newTrack;
                current = newTrack;
            }
            else
            {
                tail.Next = newTrack;
                newTrack.Previous = tail;
                tail = newTrack;
            }
        }

        public void RemoveTrack(string name)
        {
            Track track = head;
            while (track != null)
            {
                if (track.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    if (track.Previous != null)
                    {
                        track.Previous.Next = track.Next;
                    }
                    else
                    {
                        head = track.Next;
                    }

                    if (track.Next != null)
                    {
                        track.Next.Previous = track.Previous;
                    }
                    else
                    {
                        tail = track.Previous;
                    }

                    if (track == current)
                    {
                        current = track.Next ?? track.Previous;
                    }

                    break;
                }

                track = track.Next;
            }
        }

        public Track FindTrack(string name)
        {
            Track track = head;
            while (track != null)
            {
                if (track.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return track;
                }
                track = track.Next;
            }
            return null;
        }

        public Track GetNextTrack()
        {
            if (current != null)
            {
                current = current.Next ?? head; // Move to the next track or wrap to the head
            }
            return current;
        }

        public Track GetPreviousTrack()
        {
            if (current != null)
            {
                current = current.Previous ?? tail; // Move to the previous track or wrap to the tail
            }
            return current;
        }


        public void Shuffle()
        {
            // Basic shuffle logic using Fisher-Yates algorithm
            List<Track> tracks = new List<Track>();
            Track track = head;
            while (track != null)
            {
                tracks.Add(track);
                track = track.Next;
            }

            Random rand = new Random();
            for (int i = tracks.Count - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                Track temp = tracks[i];
                tracks[i] = tracks[j];
                tracks[j] = temp;
            }

            // Rebuild the linked list with shuffled order
            head = tracks.FirstOrDefault();
            tail = tracks.LastOrDefault();

            for (int i = 0; i < tracks.Count; i++)
            {
                tracks[i].Next = (i < tracks.Count - 1) ? tracks[i + 1] : null;
                tracks[i].Previous = (i > 0) ? tracks[i - 1] : null;
            }
        }

        public List<string> GetAllTrackNames()
        {
            List<string> trackNames = new List<string>();
            Track track = head;
            while (track != null)
            {
                trackNames.Add(track.Name);
                track = track.Next;
            }
            return trackNames;
        }


    }

}
