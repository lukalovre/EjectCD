using System.Runtime.InteropServices;

namespace EjectMedia
{
	internal class EjectMedia
	{
		public static void Eject(string driveLetter)
		{
			mciSendStringA($"open {driveLetter}: type CDaudio alias drive{driveLetter}", string.Empty, 0, 0);
			mciSendStringA($"set drive{driveLetter} door open", string.Empty, 0, 0);
		}

		[DllImport("winmm.dll", EntryPoint = "mciSendString")]
		public static extern int mciSendStringA(string lpstrCommand, string lpstrReturnString,
							int uReturnLength, int hwndCallback);

		internal class Program
		{
			private static void Main(string[] args)
			{
				Eject("D");
			}
		}
	}
}