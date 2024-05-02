namespace SOLID_Examples.day2.AudioPlayer_ISP
{
    public interface IMediaLoader
    {
        void LoadMedia(string filePath);
    }
    public interface IAudioPlayer: IMediaLoader
    {
        void PlayAudio();
    }
    public interface IVideoPlayer: IMediaLoader
    {
        void PlayVideo();
        void DisplaySubtitles();
    }
    public class AudioPlayer : IAudioPlayer
    {
        public void PlayAudio()
        {
            //Code to play audio
        }
        public void LoadMedia(string filePath)
        {
            //Code to load audio file
        }
    }

    public class VideoPlayer : IVideoPlayer
    {
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
