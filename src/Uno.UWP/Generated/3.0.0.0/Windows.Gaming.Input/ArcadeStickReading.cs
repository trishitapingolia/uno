#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.Gaming.Input
{
	#if __ANDROID__ || __IOS__ || NET46 || __WASM__
	[global::Uno.NotImplemented]
	#endif
	public  partial struct ArcadeStickReading 
	{
		// Forced skipping of method Windows.Gaming.Input.ArcadeStickReading.ArcadeStickReading()
		#if __ANDROID__ || __IOS__ || NET46 || __WASM__
		public  ulong Timestamp;
		#endif
		#if __ANDROID__ || __IOS__ || NET46 || __WASM__
		public  global::Windows.Gaming.Input.ArcadeStickButtons Buttons;
		#endif
	}
}