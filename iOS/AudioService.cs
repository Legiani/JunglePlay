using System;
using System.IO;
using AVFoundation;
using Foundation;
using JunglePlay.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(AudioService))]
namespace JunglePlay.iOS
{
	public class AudioService : IAudio
	{
		public void PlayAudioFile(string fileName)
		{
			string sFilePath = NSBundle.MainBundle.PathForResource(Path.GetFileNameWithoutExtension(fileName), Path.GetExtension(fileName));
			var url = NSUrl.FromString(sFilePath);
			var _player = AVAudioPlayer.FromUrl(url);
			_player.FinishedPlaying += (object sender, AVStatusEventArgs e) =>
			{
				_player = null;
			};
			_player.Play();
		}
	}
}
