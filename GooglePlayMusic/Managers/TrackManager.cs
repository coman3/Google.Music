using System;
using System.Collections.Generic;
using GoogleMusicApi.Structure;

namespace GooglePlayMusic.Desktop.Managers
{
    public class TrackManager
    {
        public static Track CurrentTrack { get; set; }
        public static Queue<Track> Queue { get; set; } = new Queue<Track>();
        public static event OnQueueChangeHandler OnQueueChange;
        public static event OnTrackDequeuedHandler OnTrackDequeued;

        public static void ChangeQueue(Queue<Track> queue)
        {
            OnQueueChange?.Invoke(Queue, new QueueChangeEventArgs
            {
                NewQueue = queue,
                OldQueue = Queue
            });
            Queue = queue;
        }

        public static Track GetNextSong()
        {
            OnTrackDequeued?.Invoke(Queue, CurrentTrack = Queue.Dequeue());
            return CurrentTrack;
        }
    }

    public delegate void OnTrackDequeuedHandler(object sender, Track track);

    public delegate void OnQueueChangeHandler(object sender, QueueChangeEventArgs args);

    public class QueueChangeEventArgs : EventArgs
    {
        public Queue<Track> OldQueue { get; set; }
        public Queue<Track> NewQueue { get; set; }

    }
}