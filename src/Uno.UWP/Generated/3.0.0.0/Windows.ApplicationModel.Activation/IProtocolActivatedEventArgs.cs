#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.ApplicationModel.Activation
{
	#if __ANDROID__ || __IOS__ || NET46 || __WASM__
	[global::Uno.NotImplemented]
	#endif
	public  partial interface IProtocolActivatedEventArgs : global::Windows.ApplicationModel.Activation.IActivatedEventArgs
	{
		#if __ANDROID__ || __IOS__ || NET46 || __WASM__
		global::System.Uri Uri
		{
			get;
		}
		#endif
		// Forced skipping of method Windows.ApplicationModel.Activation.IProtocolActivatedEventArgs.Uri.get
	}
}