namespace SOLID_Examples.day2.AudioPlayer_ISP
{
    public interface IMediaPlayer_ex
    {
        void PlayAudio();
        void PlayVideo();
        void DisplaySubtitles();
        void LoadMedia(string filePath);
    }
    public class AudioPlayer_ex : IMediaPlayer_ex
    {
        public void PlayAudio()
        {
            //Code to play audio
        }
        public void PlayVideo()
        {
            throw new NotImplementedException("Audio players cannot play videos.");
        }
        public void DisplaySubtitles()
        {
            throw new NotImplementedException("Audio players cannot display subtitles.");

        }
        public void LoadMedia(string filePath)
        {
            //Code to load audio file
        }
    }

    public class VideoPlayer_ex : IMediaPlayer_ex
    {
        public void PlayAudio()
        {
            throw new NotImplementedException("Video players cannot play audio   without video.");

        }
        public void PlayVideo()
        {
            //Code to play video
        }
        public void DisplaySubtitles()
        {
            //Code to display subtitles
        }
        public void LoadMedia(string filePath)
        {
            //Code to load video file
        }
    }
}
