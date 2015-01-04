using System;
using System.Collections.Generic;
using System.Linq;

#if MACOS
using MonoMac.AppKit;
using MonoMac.Foundation;
#endif

namespace ${Namespace}
{
#if __ANDROID__
#else
	static class Program
	{
#if !MACOS	
		private static Game1 game;

		[STAThread]
#endif
		static void Main (string[] args)
		{
#if MACOS
			NSApplication.Init ();

			using (var p = new NSAutoreleasePool ()) {
				NSApplication.SharedApplication.Delegate = new AppDelegate();
				NSApplication.Main(args);
			}
#else
			game = new Game1();
			game.Run();
#endif

		}
	}

#if MACOS
	class AppDelegate : NSApplicationDelegate
	{
		Game1 game;
		public override void FinishedLaunching (MonoMac.Foundation.NSObject notification)
		{
			game = new Game1 ();
			game.Run ();
		}

		public override bool ApplicationShouldTerminateAfterLastWindowClosed (NSApplication sender)
		{
			return true;
		}
	}  
#endif
#endif
}

