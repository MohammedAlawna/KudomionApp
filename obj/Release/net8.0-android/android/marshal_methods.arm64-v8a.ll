; ModuleID = 'marshal_methods.arm64-v8a.ll'
source_filename = "marshal_methods.arm64-v8a.ll"
target datalayout = "e-m:e-i8:8:32-i16:16:32-i64:64-i128:128-n32:64-S128"
target triple = "aarch64-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [170 x ptr] zeroinitializer, align 8

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [340 x i64] [
	i64 35222666784700157, ; 0: KudomionApp.dll => 0x7d22d42dbe76fd => 95
	i64 98382396393917666, ; 1: Microsoft.Extensions.Primitives.dll => 0x15d8644ad360ce2 => 55
	i64 120698629574877762, ; 2: Mono.Android => 0x1accec39cafe242 => 169
	i64 131669012237370309, ; 3: Microsoft.Maui.Essentials.dll => 0x1d3c844de55c3c5 => 60
	i64 196720943101637631, ; 4: System.Linq.Expressions.dll => 0x2bae4a7cd73f3ff => 117
	i64 210515253464952879, ; 5: Xamarin.AndroidX.Collection.dll => 0x2ebe681f694702f => 71
	i64 232391251801502327, ; 6: Xamarin.AndroidX.SavedState.dll => 0x3399e9cbc897277 => 88
	i64 464346026994987652, ; 7: System.Reactive.dll => 0x671b04057e67284 => 65
	i64 502670939551102150, ; 8: System.Management.dll => 0x6f9d88e66daf4c6 => 64
	i64 560278790331054453, ; 9: System.Reflection.Primitives => 0x7c6829760de3975 => 139
	i64 718159679911342543, ; 10: FirebaseAdmin.dll => 0x9f76a6c851fb1cf => 38
	i64 750875890346172408, ; 11: System.Threading.Thread => 0xa6ba5a4da7d1ff8 => 158
	i64 799765834175365804, ; 12: System.ComponentModel.dll => 0xb1956c9f18442ac => 104
	i64 805302231655005164, ; 13: hu\Microsoft.Maui.Controls.resources.dll => 0xb2d021ceea03bec => 12
	i64 872800313462103108, ; 14: Xamarin.AndroidX.DrawerLayout => 0xc1ccf42c3c21c44 => 76
	i64 1010599046655515943, ; 15: System.Reflection.Primitives.dll => 0xe065e7a82401d27 => 139
	i64 1120440138749646132, ; 16: Xamarin.Google.Android.Material.dll => 0xf8c9a5eae431534 => 92
	i64 1268860745194512059, ; 17: System.Drawing.dll => 0x119be62002c19ebb => 112
	i64 1369545283391376210, ; 18: Xamarin.AndroidX.Navigation.Fragment.dll => 0x13019a2dd85acb52 => 84
	i64 1476839205573959279, ; 19: System.Net.Primitives.dll => 0x147ec96ece9b1e6f => 125
	i64 1486715745332614827, ; 20: Microsoft.Maui.Controls.dll => 0x14a1e017ea87d6ab => 57
	i64 1492954217099365037, ; 21: System.Net.HttpListener => 0x14b809f350210aad => 122
	i64 1513467482682125403, ; 22: Mono.Android.Runtime => 0x1500eaa8245f6c5b => 168
	i64 1537168428375924959, ; 23: System.Threading.Thread.dll => 0x15551e8a954ae0df => 158
	i64 1624659445732251991, ; 24: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0x168bf32877da9957 => 68
	i64 1628611045998245443, ; 25: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0x1699fd1e1a00b643 => 81
	i64 1731380447121279447, ; 26: Newtonsoft.Json => 0x18071957e9b889d7 => 62
	i64 1735388228521408345, ; 27: System.Net.Mail.dll => 0x181556663c69b759 => 123
	i64 1743969030606105336, ; 28: System.Memory.dll => 0x1833d297e88f2af8 => 120
	i64 1767386781656293639, ; 29: System.Private.Uri.dll => 0x188704e9f5582107 => 133
	i64 1795316252682057001, ; 30: Xamarin.AndroidX.AppCompat.dll => 0x18ea3e9eac997529 => 67
	i64 1825687700144851180, ; 31: System.Runtime.InteropServices.RuntimeInformation.dll => 0x1956254a55ef08ec => 141
	i64 1835311033149317475, ; 32: es\Microsoft.Maui.Controls.resources => 0x197855a927386163 => 6
	i64 1836611346387731153, ; 33: Xamarin.AndroidX.SavedState => 0x197cf449ebe482d1 => 88
	i64 1865037103900624886, ; 34: Microsoft.Bcl.AsyncInterfaces => 0x19e1f15d56eb87f6 => 47
	i64 1875417405349196092, ; 35: System.Drawing.Primitives => 0x1a06d2319b6c713c => 111
	i64 1881198190668717030, ; 36: tr\Microsoft.Maui.Controls.resources => 0x1a1b5bc992ea9be6 => 28
	i64 1920760634179481754, ; 37: Microsoft.Maui.Controls.Xaml => 0x1aa7e99ec2d2709a => 58
	i64 1930726298510463061, ; 38: CommunityToolkit.Mvvm.dll => 0x1acb5156cd389055 => 37
	i64 1972385128188460614, ; 39: System.Security.Cryptography.Algorithms => 0x1b5f51d2edefbe46 => 149
	i64 1981742497975770890, ; 40: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x1b80904d5c241f0a => 80
	i64 2040001226662520565, ; 41: System.Threading.Tasks.Extensions.dll => 0x1c4f8a4ea894a6f5 => 156
	i64 2102659300918482391, ; 42: System.Drawing.Primitives.dll => 0x1d2e257e6aead5d7 => 111
	i64 2133195048986300728, ; 43: Newtonsoft.Json.dll => 0x1d9aa1984b735138 => 62
	i64 2165725771938924357, ; 44: Xamarin.AndroidX.Browser => 0x1e0e341d75540745 => 69
	i64 2262844636196693701, ; 45: Xamarin.AndroidX.DrawerLayout.dll => 0x1f673d352266e6c5 => 76
	i64 2287834202362508563, ; 46: System.Collections.Concurrent => 0x1fc00515e8ce7513 => 97
	i64 2329709569556905518, ; 47: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x2054ca829b447e2e => 79
	i64 2470498323731680442, ; 48: Xamarin.AndroidX.CoordinatorLayout => 0x2248f922dc398cba => 72
	i64 2497223385847772520, ; 49: System.Runtime => 0x22a7eb7046413568 => 147
	i64 2547086958574651984, ; 50: Xamarin.AndroidX.Activity.dll => 0x2359121801df4a50 => 66
	i64 2602673633151553063, ; 51: th\Microsoft.Maui.Controls.resources => 0x241e8de13a460e27 => 27
	i64 2632269733008246987, ; 52: System.Net.NameResolution => 0x2487b36034f808cb => 124
	i64 2656907746661064104, ; 53: Microsoft.Extensions.DependencyInjection => 0x24df3b84c8b75da8 => 50
	i64 2662981627730767622, ; 54: cs\Microsoft.Maui.Controls.resources => 0x24f4cfae6c48af06 => 2
	i64 2812926542227278819, ; 55: Google.Apis.Core.dll => 0x270985c960b98be3 => 45
	i64 2895129759130297543, ; 56: fi\Microsoft.Maui.Controls.resources => 0x282d912d479fa4c7 => 7
	i64 3017704767998173186, ; 57: Xamarin.Google.Android.Material => 0x29e10a7f7d88a002 => 92
	i64 3289520064315143713, ; 58: Xamarin.AndroidX.Lifecycle.Common => 0x2da6b911e3063621 => 78
	i64 3311221304742556517, ; 59: System.Numerics.Vectors.dll => 0x2df3d23ba9e2b365 => 131
	i64 3325875462027654285, ; 60: System.Runtime.Numerics => 0x2e27e21c8958b48d => 144
	i64 3328853167529574890, ; 61: System.Net.Sockets.dll => 0x2e327651a008c1ea => 129
	i64 3344514922410554693, ; 62: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x2e6a1a9a18463545 => 94
	i64 3429672777697402584, ; 63: Microsoft.Maui.Essentials => 0x2f98a5385a7b1ed8 => 60
	i64 3494946837667399002, ; 64: Microsoft.Extensions.Configuration => 0x30808ba1c00a455a => 48
	i64 3522470458906976663, ; 65: Xamarin.AndroidX.SwipeRefreshLayout => 0x30e2543832f52197 => 89
	i64 3551103847008531295, ; 66: System.Private.CoreLib.dll => 0x31480e226177735f => 166
	i64 3567343442040498961, ; 67: pt\Microsoft.Maui.Controls.resources => 0x3181bff5bea4ab11 => 22
	i64 3571415421602489686, ; 68: System.Runtime.dll => 0x319037675df7e556 => 147
	i64 3638003163729360188, ; 69: Microsoft.Extensions.Configuration.Abstractions => 0x327cc89a39d5f53c => 49
	i64 3647754201059316852, ; 70: System.Xml.ReaderWriter => 0x329f6d1e86145474 => 162
	i64 3655542548057982301, ; 71: Microsoft.Extensions.Configuration.dll => 0x32bb18945e52855d => 48
	i64 3716579019761409177, ; 72: netstandard.dll => 0x3393f0ed5c8c5c99 => 165
	i64 3727469159507183293, ; 73: Xamarin.AndroidX.RecyclerView => 0x33baa1739ba646bd => 87
	i64 3869221888984012293, ; 74: Microsoft.Extensions.Logging.dll => 0x35b23cceda0ed605 => 52
	i64 3890352374528606784, ; 75: Microsoft.Maui.Controls.Xaml.dll => 0x35fd4edf66e00240 => 58
	i64 3933965368022646939, ; 76: System.Net.Requests => 0x369840a8bfadc09b => 126
	i64 3966267475168208030, ; 77: System.Memory => 0x370b03412596249e => 120
	i64 4009997192427317104, ; 78: System.Runtime.Serialization.Primitives => 0x37a65f335cf1a770 => 146
	i64 4056584864658557221, ; 79: Google.Apis.Auth => 0x384be27113330925 => 44
	i64 4070326265757318011, ; 80: da\Microsoft.Maui.Controls.resources.dll => 0x387cb42c56683b7b => 3
	i64 4073500526318903918, ; 81: System.Private.Xml.dll => 0x3887fb25779ae26e => 135
	i64 4073631083018132676, ; 82: Microsoft.Maui.Controls.Compatibility.dll => 0x388871e311491cc4 => 56
	i64 4120493066591692148, ; 83: zh-Hant\Microsoft.Maui.Controls.resources => 0x392eee9cdda86574 => 33
	i64 4154383907710350974, ; 84: System.ComponentModel => 0x39a7562737acb67e => 104
	i64 4168469861834746866, ; 85: System.Security.Claims.dll => 0x39d96140fb94ebf2 => 148
	i64 4187479170553454871, ; 86: System.Linq.Expressions => 0x3a1cea1e912fa117 => 117
	i64 4205801962323029395, ; 87: System.ComponentModel.TypeConverter => 0x3a5e0299f7e7ad93 => 103
	i64 4360412976914417659, ; 88: tr\Microsoft.Maui.Controls.resources.dll => 0x3c834c8002fcc7fb => 28
	i64 4373617458794931033, ; 89: System.IO.Pipes.dll => 0x3cb235e806eb2359 => 116
	i64 4477672992252076438, ; 90: System.Web.HttpUtility.dll => 0x3e23e3dcdb8ba196 => 160
	i64 4794310189461587505, ; 91: Xamarin.AndroidX.Activity => 0x4288cfb749e4c631 => 66
	i64 4795410492532947900, ; 92: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0x428cb86f8f9b7bbc => 89
	i64 4809057822547766521, ; 93: System.Drawing => 0x42bd349c3145ecf9 => 112
	i64 4814660307502931973, ; 94: System.Net.NameResolution.dll => 0x42d11c0a5ee2a005 => 124
	i64 4853321196694829351, ; 95: System.Runtime.Loader.dll => 0x435a75ea15de7927 => 143
	i64 4871824391508510238, ; 96: nb\Microsoft.Maui.Controls.resources.dll => 0x439c3278d7f2c61e => 18
	i64 4953714692329509532, ; 97: sv\Microsoft.Maui.Controls.resources.dll => 0x44bf21444aef129c => 26
	i64 5103417709280584325, ; 98: System.Collections.Specialized => 0x46d2fb5e161b6285 => 100
	i64 5182934613077526976, ; 99: System.Collections.Specialized.dll => 0x47ed7b91fa9009c0 => 100
	i64 5290786973231294105, ; 100: System.Runtime.Loader => 0x496ca6b869b72699 => 143
	i64 5423376490970181369, ; 101: System.Runtime.InteropServices.RuntimeInformation => 0x4b43b42f2b7b6ef9 => 141
	i64 5446034149219586269, ; 102: System.Diagnostics.Debug => 0x4b94333452e150dd => 107
	i64 5471532531798518949, ; 103: sv\Microsoft.Maui.Controls.resources => 0x4beec9d926d82ca5 => 26
	i64 5522859530602327440, ; 104: uk\Microsoft.Maui.Controls.resources => 0x4ca5237b51eead90 => 29
	i64 5570799893513421663, ; 105: System.IO.Compression.Brotli => 0x4d4f74fcdfa6c35f => 114
	i64 5573260873512690141, ; 106: System.Security.Cryptography.dll => 0x4d58333c6e4ea1dd => 152
	i64 5650097808083101034, ; 107: System.Security.Cryptography.Algorithms.dll => 0x4e692e055d01a56a => 149
	i64 5665389054145784248, ; 108: Google.Apis.Core => 0x4e9f815406bee9b8 => 45
	i64 5692067934154308417, ; 109: Xamarin.AndroidX.ViewPager2.dll => 0x4efe49a0d4a8bb41 => 91
	i64 5979151488806146654, ; 110: System.Formats.Asn1 => 0x52fa3699a489d25e => 113
	i64 5984759512290286505, ; 111: System.Security.Cryptography.Primitives => 0x530e23115c33dba9 => 150
	i64 6200764641006662125, ; 112: ro\Microsoft.Maui.Controls.resources => 0x560d8a96830131ed => 23
	i64 6218967553231149354, ; 113: Firebase.Auth.dll => 0x564e360a4805d92a => 39
	i64 6284145129771520194, ; 114: System.Reflection.Emit.ILGeneration => 0x5735c4b3610850c2 => 136
	i64 6300676701234028427, ; 115: es\Microsoft.Maui.Controls.resources.dll => 0x57708013cda25f8b => 6
	i64 6357457916754632952, ; 116: _Microsoft.Android.Resource.Designer => 0x583a3a4ac2a7a0f8 => 34
	i64 6401687960814735282, ; 117: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0x58d75d486341cfb2 => 79
	i64 6471714727257221498, ; 118: fi\Microsoft.Maui.Controls.resources.dll => 0x59d026417dd4a97a => 7
	i64 6478287442656530074, ; 119: hr\Microsoft.Maui.Controls.resources => 0x59e7801b0c6a8e9a => 11
	i64 6504860066809920875, ; 120: Xamarin.AndroidX.Browser.dll => 0x5a45e7c43bd43d6b => 69
	i64 6548213210057960872, ; 121: Xamarin.AndroidX.CustomView.dll => 0x5adfed387b066da8 => 75
	i64 6560151584539558821, ; 122: Microsoft.Extensions.Options => 0x5b0a571be53243a5 => 54
	i64 6743165466166707109, ; 123: nl\Microsoft.Maui.Controls.resources => 0x5d948943c08c43a5 => 19
	i64 6786606130239981554, ; 124: System.Diagnostics.TraceSource => 0x5e2ede51877147f2 => 110
	i64 6814185388980153342, ; 125: System.Xml.XDocument.dll => 0x5e90d98217d1abfe => 163
	i64 6876862101832370452, ; 126: System.Xml.Linq => 0x5f6f85a57d108914 => 161
	i64 6894844156784520562, ; 127: System.Numerics.Vectors => 0x5faf683aead1ad72 => 131
	i64 6934772601320367100, ; 128: Google.Api.Gax.Rest => 0x603d42f05bcfe3fc => 42
	i64 6987056692196838363, ; 129: System.Management => 0x60f7030ae3e88bdb => 64
	i64 7083547580668757502, ; 130: System.Private.Xml.Linq.dll => 0x624dd0fe8f56c5fe => 134
	i64 7270811800166795866, ; 131: System.Linq => 0x64e71ccf51a90a5a => 119
	i64 7338192458477945005, ; 132: System.Reflection => 0x65d67f295d0740ad => 140
	i64 7377312882064240630, ; 133: System.ComponentModel.TypeConverter.dll => 0x66617afac45a2ff6 => 103
	i64 7488575175965059935, ; 134: System.Xml.Linq.dll => 0x67ecc3724534ab5f => 161
	i64 7489048572193775167, ; 135: System.ObjectModel => 0x67ee71ff6b419e3f => 132
	i64 7592577537120840276, ; 136: System.Diagnostics.Process => 0x695e410af5b2aa54 => 109
	i64 7602111570124318452, ; 137: System.Reactive => 0x698020320025a6f4 => 65
	i64 7654504624184590948, ; 138: System.Net.Http => 0x6a3a4366801b8264 => 121
	i64 7694700312542370399, ; 139: System.Net.Mail => 0x6ac9112a7e2cda5f => 123
	i64 7714652370974252055, ; 140: System.Private.CoreLib => 0x6b0ff375198b9c17 => 166
	i64 7735176074855944702, ; 141: Microsoft.CSharp => 0x6b58dda848e391fe => 96
	i64 7735352534559001595, ; 142: Xamarin.Kotlin.StdLib.dll => 0x6b597e2582ce8bfb => 93
	i64 7742555799473854801, ; 143: it\Microsoft.Maui.Controls.resources.dll => 0x6b73157a51479951 => 14
	i64 7836164640616011524, ; 144: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x6cbfa6390d64d704 => 68
	i64 7975724199463739455, ; 145: sk\Microsoft.Maui.Controls.resources.dll => 0x6eaf76e6f785e03f => 25
	i64 8064050204834738623, ; 146: System.Collections.dll => 0x6fe942efa61731bf => 101
	i64 8083354569033831015, ; 147: Xamarin.AndroidX.Lifecycle.Common.dll => 0x702dd82730cad267 => 78
	i64 8087206902342787202, ; 148: System.Diagnostics.DiagnosticSource => 0x703b87d46f3aa082 => 108
	i64 8108129031893776750, ; 149: ko\Microsoft.Maui.Controls.resources.dll => 0x7085dc65530f796e => 16
	i64 8113615946733131500, ; 150: System.Reflection.Extensions => 0x70995ab73cf916ec => 138
	i64 8167236081217502503, ; 151: Java.Interop.dll => 0x7157d9f1a9b8fd27 => 167
	i64 8185542183669246576, ; 152: System.Collections => 0x7198e33f4794aa70 => 101
	i64 8246048515196606205, ; 153: Microsoft.Maui.Graphics.dll => 0x726fd96f64ee56fd => 61
	i64 8264926008854159966, ; 154: System.Diagnostics.Process.dll => 0x72b2ea6a64a3a25e => 109
	i64 8368701292315763008, ; 155: System.Security.Cryptography => 0x7423997c6fd56140 => 152
	i64 8386351099740279196, ; 156: zh-HK\Microsoft.Maui.Controls.resources.dll => 0x74624de475b9d19c => 31
	i64 8400357532724379117, ; 157: Xamarin.AndroidX.Navigation.UI.dll => 0x749410ab44503ded => 86
	i64 8410671156615598628, ; 158: System.Reflection.Emit.Lightweight.dll => 0x74b8b4daf4b25224 => 137
	i64 8518412311883997971, ; 159: System.Collections.Immutable => 0x76377add7c28e313 => 98
	i64 8563666267364444763, ; 160: System.Private.Uri => 0x76d841191140ca5b => 133
	i64 8599632406834268464, ; 161: CommunityToolkit.Maui => 0x7758081c784b4930 => 35
	i64 8626175481042262068, ; 162: Java.Interop => 0x77b654e585b55834 => 167
	i64 8638972117149407195, ; 163: Microsoft.CSharp.dll => 0x77e3cb5e8b31d7db => 96
	i64 8639588376636138208, ; 164: Xamarin.AndroidX.Navigation.Runtime => 0x77e5fbdaa2fda2e0 => 85
	i64 8677882282824630478, ; 165: pt-BR\Microsoft.Maui.Controls.resources => 0x786e07f5766b00ce => 21
	i64 8702320156596882678, ; 166: Firebase.dll => 0x78c4da1357adccf6 => 40
	i64 8725526185868997716, ; 167: System.Diagnostics.DiagnosticSource.dll => 0x79174bd613173454 => 108
	i64 8941376889969657626, ; 168: System.Xml.XDocument => 0x7c1626e87187471a => 163
	i64 9045785047181495996, ; 169: zh-HK\Microsoft.Maui.Controls.resources => 0x7d891592e3cb0ebc => 31
	i64 9057635389615298436, ; 170: LiteDB => 0x7db32f65bf06d784 => 46
	i64 9296667808972889535, ; 171: LiteDB.dll => 0x8104661dcca35dbf => 46
	i64 9312692141327339315, ; 172: Xamarin.AndroidX.ViewPager2 => 0x813d54296a634f33 => 91
	i64 9324707631942237306, ; 173: Xamarin.AndroidX.AppCompat => 0x8168042fd44a7c7a => 67
	i64 9363564275759486853, ; 174: el\Microsoft.Maui.Controls.resources.dll => 0x81f21019382e9785 => 5
	i64 9551379474083066910, ; 175: uk\Microsoft.Maui.Controls.resources.dll => 0x848d5106bbadb41e => 29
	i64 9659729154652888475, ; 176: System.Text.RegularExpressions => 0x860e407c9991dd9b => 155
	i64 9678050649315576968, ; 177: Xamarin.AndroidX.CoordinatorLayout.dll => 0x864f57c9feb18c88 => 72
	i64 9702891218465930390, ; 178: System.Collections.NonGeneric.dll => 0x86a79827b2eb3c96 => 99
	i64 9773637193738963987, ; 179: ca\Microsoft.Maui.Controls.resources.dll => 0x87a2ef3ea85b4c13 => 1
	i64 9808709177481450983, ; 180: Mono.Android.dll => 0x881f890734e555e7 => 169
	i64 9933555792566666578, ; 181: System.Linq.Queryable.dll => 0x89db145cf475c552 => 118
	i64 9956195530459977388, ; 182: Microsoft.Maui => 0x8a2b8315b36616ac => 59
	i64 9959489431142554298, ; 183: System.CodeDom => 0x8a3736deb7825aba => 63
	i64 10038780035334861115, ; 184: System.Net.Http.dll => 0x8b50e941206af13b => 121
	i64 10051358222726253779, ; 185: System.Private.Xml => 0x8b7d990c97ccccd3 => 135
	i64 10092835686693276772, ; 186: Microsoft.Maui.Controls => 0x8c10f49539bd0c64 => 57
	i64 10143853363526200146, ; 187: da\Microsoft.Maui.Controls.resources => 0x8cc634e3c2a16b52 => 3
	i64 10144742755892837524, ; 188: Firebase => 0x8cc95dc98eb5bc94 => 40
	i64 10209869394718195525, ; 189: nl\Microsoft.Maui.Controls.resources.dll => 0x8db0be1ecb4f7f45 => 19
	i64 10220684565739810458, ; 190: FirebaseAdmin => 0x8dd72a76063d2e9a => 38
	i64 10229024438826829339, ; 191: Xamarin.AndroidX.CustomView => 0x8df4cb880b10061b => 75
	i64 10236703004850800690, ; 192: System.Net.ServicePoint.dll => 0x8e101325834e4832 => 128
	i64 10245369515835430794, ; 193: System.Reflection.Emit.Lightweight => 0x8e2edd4ad7fc978a => 137
	i64 10360651442923773544, ; 194: System.Text.Encoding => 0x8fc86d98211c1e68 => 154
	i64 10364469296367737616, ; 195: System.Reflection.Emit.ILGeneration.dll => 0x8fd5fde967711b10 => 136
	i64 10406448008575299332, ; 196: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x906b2153fcb3af04 => 94
	i64 10430153318873392755, ; 197: Xamarin.AndroidX.Core => 0x90bf592ea44f6673 => 73
	i64 10447083246144586668, ; 198: Microsoft.Bcl.AsyncInterfaces.dll => 0x90fb7edc816203ac => 47
	i64 10506226065143327199, ; 199: ca\Microsoft.Maui.Controls.resources => 0x91cd9cf11ed169df => 1
	i64 10761706286639228993, ; 200: zh-Hant\Microsoft.Maui.Controls.resources.dll => 0x955942d988382841 => 33
	i64 10785150219063592792, ; 201: System.Net.Primitives => 0x95ac8cfb68830758 => 125
	i64 10822644899632537592, ; 202: System.Linq.Queryable => 0x9631c23204ca5ff8 => 118
	i64 10823124638835005028, ; 203: Google.Api.Gax.dll => 0x963376840189d664 => 41
	i64 10880838204485145808, ; 204: CommunityToolkit.Maui.dll => 0x970080b2a4d614d0 => 35
	i64 11002576679268595294, ; 205: Microsoft.Extensions.Logging.Abstractions => 0x98b1013215cd365e => 53
	i64 11009005086950030778, ; 206: Microsoft.Maui.dll => 0x98c7d7cc621ffdba => 59
	i64 11103970607964515343, ; 207: hu\Microsoft.Maui.Controls.resources => 0x9a193a6fc41a6c0f => 12
	i64 11156122287428000958, ; 208: th\Microsoft.Maui.Controls.resources.dll => 0x9ad2821cdcf6dcbe => 27
	i64 11157797727133427779, ; 209: fr\Microsoft.Maui.Controls.resources.dll => 0x9ad875ea9172e843 => 8
	i64 11162124722117608902, ; 210: Xamarin.AndroidX.ViewPager => 0x9ae7d54b986d05c6 => 90
	i64 11220793807500858938, ; 211: ja\Microsoft.Maui.Controls.resources => 0x9bb8448481fdd63a => 15
	i64 11226290749488709958, ; 212: Microsoft.Extensions.Options.dll => 0x9bcbcbf50c874146 => 54
	i64 11340910727871153756, ; 213: Xamarin.AndroidX.CursorAdapter => 0x9d630238642d465c => 74
	i64 11485890710487134646, ; 214: System.Runtime.InteropServices => 0x9f6614bf0f8b71b6 => 142
	i64 11518296021396496455, ; 215: id\Microsoft.Maui.Controls.resources => 0x9fd9353475222047 => 13
	i64 11529969570048099689, ; 216: Xamarin.AndroidX.ViewPager.dll => 0xa002ae3c4dc7c569 => 90
	i64 11530571088791430846, ; 217: Microsoft.Extensions.Logging => 0xa004d1504ccd66be => 52
	i64 11597940890313164233, ; 218: netstandard => 0xa0f429ca8d1805c9 => 165
	i64 11743665907891708234, ; 219: System.Threading.Tasks => 0xa2f9e1ec30c0214a => 157
	i64 11855031688536399763, ; 220: vi\Microsoft.Maui.Controls.resources.dll => 0xa485888294361f93 => 30
	i64 12040886584167504988, ; 221: System.Net.ServicePoint => 0xa719d28d8e121c5c => 128
	i64 12123043025855404482, ; 222: System.Reflection.Extensions.dll => 0xa83db366c0e359c2 => 138
	i64 12201331334810686224, ; 223: System.Runtime.Serialization.Primitives.dll => 0xa953d6341e3bd310 => 146
	i64 12269460666702402136, ; 224: System.Collections.Immutable.dll => 0xaa45e178506c9258 => 98
	i64 12341818387765915815, ; 225: CommunityToolkit.Maui.Core.dll => 0xab46f26f152bf0a7 => 36
	i64 12437742355241350664, ; 226: Google.Apis.dll => 0xac9bbcc62bfdb608 => 43
	i64 12451044538927396471, ; 227: Xamarin.AndroidX.Fragment.dll => 0xaccaff0a2955b677 => 77
	i64 12466513435562512481, ; 228: Xamarin.AndroidX.Loader.dll => 0xad01f3eb52569061 => 82
	i64 12475113361194491050, ; 229: _Microsoft.Android.Resource.Designer.dll => 0xad2081818aba1caa => 34
	i64 12517810545449516888, ; 230: System.Diagnostics.TraceSource.dll => 0xadb8325e6f283f58 => 110
	i64 12528155905152483962, ; 231: Firebase.Auth => 0xaddcf36b3153827a => 39
	i64 12538491095302438457, ; 232: Xamarin.AndroidX.CardView.dll => 0xae01ab382ae67e39 => 70
	i64 12550732019250633519, ; 233: System.IO.Compression => 0xae2d28465e8e1b2f => 115
	i64 12700543734426720211, ; 234: Xamarin.AndroidX.Collection => 0xb041653c70d157d3 => 71
	i64 12708922737231849740, ; 235: System.Text.Encoding.Extensions => 0xb05f29e50e96e90c => 153
	i64 12722065664929968482, ; 236: Google.Api.Gax.Rest.dll => 0xb08ddb515f583162 => 42
	i64 12835242264250840079, ; 237: System.IO.Pipes => 0xb21ff0d5d6c0740f => 116
	i64 12843321153144804894, ; 238: Microsoft.Extensions.Primitives => 0xb23ca48abd74d61e => 55
	i64 12859557719246324186, ; 239: System.Net.WebHeaderCollection.dll => 0xb276539ce04f41da => 130
	i64 12958614573187252691, ; 240: Google.Apis => 0xb3d63f4bf006c1d3 => 43
	i64 12989346753972519995, ; 241: ar\Microsoft.Maui.Controls.resources.dll => 0xb4436e0d5ee7c43b => 0
	i64 13005833372463390146, ; 242: pt-BR\Microsoft.Maui.Controls.resources.dll => 0xb47e008b5d99ddc2 => 21
	i64 13068258254871114833, ; 243: System.Runtime.Serialization.Formatters.dll => 0xb55bc7a4eaa8b451 => 145
	i64 13343850469010654401, ; 244: Mono.Android.Runtime.dll => 0xb92ee14d854f44c1 => 168
	i64 13347553336798099327, ; 245: KudomionApp => 0xb93c090a9c6e377f => 95
	i64 13381594904270902445, ; 246: he\Microsoft.Maui.Controls.resources => 0xb9b4f9aaad3e94ad => 9
	i64 13465488254036897740, ; 247: Xamarin.Kotlin.StdLib => 0xbadf06394d106fcc => 93
	i64 13540124433173649601, ; 248: vi\Microsoft.Maui.Controls.resources => 0xbbe82f6eede718c1 => 30
	i64 13572454107664307259, ; 249: Xamarin.AndroidX.RecyclerView.dll => 0xbc5b0b19d99f543b => 87
	i64 13717397318615465333, ; 250: System.ComponentModel.Primitives.dll => 0xbe5dfc2ef2f87d75 => 102
	i64 13782512541859110153, ; 251: Google.Apis.Auth.dll => 0xbf45522249e0dd09 => 44
	i64 13881769479078963060, ; 252: System.Console.dll => 0xc0a5f3cade5c6774 => 105
	i64 13959074834287824816, ; 253: Xamarin.AndroidX.Fragment => 0xc1b8989a7ad20fb0 => 77
	i64 14124974489674258913, ; 254: Xamarin.AndroidX.CardView => 0xc405fd76067d19e1 => 70
	i64 14125464355221830302, ; 255: System.Threading.dll => 0xc407bafdbc707a9e => 159
	i64 14254574811015963973, ; 256: System.Text.Encoding.Extensions.dll => 0xc5d26c4442d66545 => 153
	i64 14327695147300244862, ; 257: System.Reflection.dll => 0xc6d632d338eb4d7e => 140
	i64 14327709162229390963, ; 258: System.Security.Cryptography.X509Certificates => 0xc6d63f9253cade73 => 151
	i64 14349907877893689639, ; 259: ro\Microsoft.Maui.Controls.resources.dll => 0xc7251d2f956ed127 => 23
	i64 14461014870687870182, ; 260: System.Net.Requests.dll => 0xc8afd8683afdece6 => 126
	i64 14464374589798375073, ; 261: ru\Microsoft.Maui.Controls.resources => 0xc8bbc80dcb1e5ea1 => 24
	i64 14491877563792607819, ; 262: zh-Hans\Microsoft.Maui.Controls.resources.dll => 0xc91d7ddcee4fca4b => 32
	i64 14556034074661724008, ; 263: CommunityToolkit.Maui.Core => 0xca016bdea6b19f68 => 36
	i64 14561513370130550166, ; 264: System.Security.Cryptography.Primitives.dll => 0xca14e3428abb8d96 => 150
	i64 14610046442689856844, ; 265: cs\Microsoft.Maui.Controls.resources.dll => 0xcac14fd5107d054c => 2
	i64 14622043554576106986, ; 266: System.Runtime.Serialization.Formatters => 0xcaebef2458cc85ea => 145
	i64 14669215534098758659, ; 267: Microsoft.Extensions.DependencyInjection.dll => 0xcb9385ceb3993c03 => 50
	i64 14690985099581930927, ; 268: System.Web.HttpUtility => 0xcbe0dd1ca5233daf => 160
	i64 14705122255218365489, ; 269: ko\Microsoft.Maui.Controls.resources => 0xcc1316c7b0fb5431 => 16
	i64 14735017007120366644, ; 270: ja\Microsoft.Maui.Controls.resources.dll => 0xcc7d4be604bfbc34 => 15
	i64 14744092281598614090, ; 271: zh-Hans\Microsoft.Maui.Controls.resources => 0xcc9d89d004439a4a => 32
	i64 14832630590065248058, ; 272: System.Security.Claims => 0xcdd816ef5d6e873a => 148
	i64 14852515768018889994, ; 273: Xamarin.AndroidX.CursorAdapter.dll => 0xce1ebc6625a76d0a => 74
	i64 14904040806490515477, ; 274: ar\Microsoft.Maui.Controls.resources => 0xced5ca2604cb2815 => 0
	i64 14954917835170835695, ; 275: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xcf8a8a895a82ecef => 51
	i64 14984936317414011727, ; 276: System.Net.WebHeaderCollection => 0xcff5302fe54ff34f => 130
	i64 14987728460634540364, ; 277: System.IO.Compression.dll => 0xcfff1ba06622494c => 115
	i64 15015154896917945444, ; 278: System.Net.Security.dll => 0xd0608bd33642dc64 => 127
	i64 15076659072870671916, ; 279: System.ObjectModel.dll => 0xd13b0d8c1620662c => 132
	i64 15111608613780139878, ; 280: ms\Microsoft.Maui.Controls.resources => 0xd1b737f831192f66 => 17
	i64 15115185479366240210, ; 281: System.IO.Compression.Brotli.dll => 0xd1c3ed1c1bc467d2 => 114
	i64 15133485256822086103, ; 282: System.Linq.dll => 0xd204f0a9127dd9d7 => 119
	i64 15203009853192377507, ; 283: pt\Microsoft.Maui.Controls.resources.dll => 0xd2fbf0e9984b94a3 => 22
	i64 15227001540531775957, ; 284: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd3512d3999b8e9d5 => 49
	i64 15370334346939861994, ; 285: Xamarin.AndroidX.Core.dll => 0xd54e65a72c560bea => 73
	i64 15391712275433856905, ; 286: Microsoft.Extensions.DependencyInjection.Abstractions => 0xd59a58c406411f89 => 51
	i64 15526743539506359484, ; 287: System.Text.Encoding.dll => 0xd77a12fc26de2cbc => 154
	i64 15527772828719725935, ; 288: System.Console => 0xd77dbb1e38cd3d6f => 105
	i64 15530465045505749832, ; 289: System.Net.HttpListener.dll => 0xd7874bacc9fdb348 => 122
	i64 15536481058354060254, ; 290: de\Microsoft.Maui.Controls.resources => 0xd79cab34eec75bde => 4
	i64 15541854775306130054, ; 291: System.Security.Cryptography.X509Certificates.dll => 0xd7afc292e8d49286 => 151
	i64 15557562860424774966, ; 292: System.Net.Sockets => 0xd7e790fe7a6dc536 => 129
	i64 15582737692548360875, ; 293: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xd841015ed86f6aab => 81
	i64 15609085926864131306, ; 294: System.dll => 0xd89e9cf3334914ea => 164
	i64 15661133872274321916, ; 295: System.Xml.ReaderWriter.dll => 0xd9578647d4bfb1fc => 162
	i64 15783653065526199428, ; 296: el\Microsoft.Maui.Controls.resources => 0xdb0accd674b1c484 => 5
	i64 15817206913877585035, ; 297: System.Threading.Tasks.dll => 0xdb8201e29086ac8b => 157
	i64 15928521404965645318, ; 298: Microsoft.Maui.Controls.Compatibility => 0xdd0d79d32c2eec06 => 56
	i64 15963349826457351533, ; 299: System.Threading.Tasks.Extensions => 0xdd893616f748b56d => 156
	i64 16056281320585338352, ; 300: ru\Microsoft.Maui.Controls.resources.dll => 0xded35eca8f3a9df0 => 24
	i64 16154507427712707110, ; 301: System => 0xe03056ea4e39aa26 => 164
	i64 16219561732052121626, ; 302: System.Net.Security => 0xe1177575db7c781a => 127
	i64 16288847719894691167, ; 303: nb\Microsoft.Maui.Controls.resources => 0xe20d9cb300c12d5f => 18
	i64 16321164108206115771, ; 304: Microsoft.Extensions.Logging.Abstractions.dll => 0xe2806c487e7b0bbb => 53
	i64 16648892297579399389, ; 305: CommunityToolkit.Mvvm => 0xe70cbf55c4f508dd => 37
	i64 16649148416072044166, ; 306: Microsoft.Maui.Graphics => 0xe70da84600bb4e86 => 61
	i64 16677317093839702854, ; 307: Xamarin.AndroidX.Navigation.UI => 0xe771bb8960dd8b46 => 86
	i64 16803648858859583026, ; 308: ms\Microsoft.Maui.Controls.resources.dll => 0xe9328d9b8ab93632 => 17
	i64 16856067890322379635, ; 309: System.Data.Common.dll => 0xe9ecc87060889373 => 106
	i64 16890310621557459193, ; 310: System.Text.RegularExpressions.dll => 0xea66700587f088f9 => 155
	i64 16942731696432749159, ; 311: sk\Microsoft.Maui.Controls.resources => 0xeb20acb622a01a67 => 25
	i64 16955525858597485057, ; 312: Google.Api.Gax => 0xeb4e20ef25a73a01 => 41
	i64 16998075588627545693, ; 313: Xamarin.AndroidX.Navigation.Fragment => 0xebe54bb02d623e5d => 84
	i64 17008137082415910100, ; 314: System.Collections.NonGeneric => 0xec090a90408c8cd4 => 99
	i64 17031351772568316411, ; 315: Xamarin.AndroidX.Navigation.Common.dll => 0xec5b843380a769fb => 83
	i64 17062143951396181894, ; 316: System.ComponentModel.Primitives => 0xecc8e986518c9786 => 102
	i64 17203614576212522419, ; 317: pl\Microsoft.Maui.Controls.resources.dll => 0xeebf844ef3e135b3 => 20
	i64 17230721278011714856, ; 318: System.Private.Xml.Linq => 0xef1fd1b5c7a72d28 => 134
	i64 17260702271250283638, ; 319: System.Data.Common => 0xef8a5543bba6bc76 => 106
	i64 17310278548634113468, ; 320: hi\Microsoft.Maui.Controls.resources.dll => 0xf03a76a04e6695bc => 10
	i64 17342750010158924305, ; 321: hi\Microsoft.Maui.Controls.resources => 0xf0add33f97ecc211 => 10
	i64 17514990004910432069, ; 322: fr\Microsoft.Maui.Controls.resources => 0xf311be9c6f341f45 => 8
	i64 17623389608345532001, ; 323: pl\Microsoft.Maui.Controls.resources => 0xf492db79dfbef661 => 20
	i64 17685921127322830888, ; 324: System.Diagnostics.Debug.dll => 0xf571038fafa74828 => 107
	i64 17704177640604968747, ; 325: Xamarin.AndroidX.Loader => 0xf5b1dfc36cac272b => 82
	i64 17710060891934109755, ; 326: Xamarin.AndroidX.Lifecycle.ViewModel => 0xf5c6c68c9e45303b => 80
	i64 17712670374920797664, ; 327: System.Runtime.InteropServices.dll => 0xf5d00bdc38bd3de0 => 142
	i64 17743407583038752114, ; 328: System.CodeDom.dll => 0xf63d3f302bff4572 => 63
	i64 17777860260071588075, ; 329: System.Runtime.Numerics.dll => 0xf6b7a5b72419c0eb => 144
	i64 17827813215687577648, ; 330: hr\Microsoft.Maui.Controls.resources.dll => 0xf7691da9f3129030 => 11
	i64 17942426894774770628, ; 331: de\Microsoft.Maui.Controls.resources.dll => 0xf9004e329f771bc4 => 4
	i64 18025913125965088385, ; 332: System.Threading => 0xfa28e87b91334681 => 159
	i64 18121036031235206392, ; 333: Xamarin.AndroidX.Navigation.Common => 0xfb7ada42d3d42cf8 => 83
	i64 18146411883821974900, ; 334: System.Formats.Asn1.dll => 0xfbd50176eb22c574 => 113
	i64 18245806341561545090, ; 335: System.Collections.Concurrent.dll => 0xfd3620327d587182 => 97
	i64 18305135509493619199, ; 336: Xamarin.AndroidX.Navigation.Runtime.dll => 0xfe08e7c2d8c199ff => 85
	i64 18324163916253801303, ; 337: it\Microsoft.Maui.Controls.resources => 0xfe4c81ff0a56ab57 => 14
	i64 18342408478508122430, ; 338: id\Microsoft.Maui.Controls.resources.dll => 0xfe8d53543697013e => 13
	i64 18358161419737137786 ; 339: he\Microsoft.Maui.Controls.resources.dll => 0xfec54a8ba8b6827a => 9
], align 8

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [340 x i32] [
	i32 95, ; 0
	i32 55, ; 1
	i32 169, ; 2
	i32 60, ; 3
	i32 117, ; 4
	i32 71, ; 5
	i32 88, ; 6
	i32 65, ; 7
	i32 64, ; 8
	i32 139, ; 9
	i32 38, ; 10
	i32 158, ; 11
	i32 104, ; 12
	i32 12, ; 13
	i32 76, ; 14
	i32 139, ; 15
	i32 92, ; 16
	i32 112, ; 17
	i32 84, ; 18
	i32 125, ; 19
	i32 57, ; 20
	i32 122, ; 21
	i32 168, ; 22
	i32 158, ; 23
	i32 68, ; 24
	i32 81, ; 25
	i32 62, ; 26
	i32 123, ; 27
	i32 120, ; 28
	i32 133, ; 29
	i32 67, ; 30
	i32 141, ; 31
	i32 6, ; 32
	i32 88, ; 33
	i32 47, ; 34
	i32 111, ; 35
	i32 28, ; 36
	i32 58, ; 37
	i32 37, ; 38
	i32 149, ; 39
	i32 80, ; 40
	i32 156, ; 41
	i32 111, ; 42
	i32 62, ; 43
	i32 69, ; 44
	i32 76, ; 45
	i32 97, ; 46
	i32 79, ; 47
	i32 72, ; 48
	i32 147, ; 49
	i32 66, ; 50
	i32 27, ; 51
	i32 124, ; 52
	i32 50, ; 53
	i32 2, ; 54
	i32 45, ; 55
	i32 7, ; 56
	i32 92, ; 57
	i32 78, ; 58
	i32 131, ; 59
	i32 144, ; 60
	i32 129, ; 61
	i32 94, ; 62
	i32 60, ; 63
	i32 48, ; 64
	i32 89, ; 65
	i32 166, ; 66
	i32 22, ; 67
	i32 147, ; 68
	i32 49, ; 69
	i32 162, ; 70
	i32 48, ; 71
	i32 165, ; 72
	i32 87, ; 73
	i32 52, ; 74
	i32 58, ; 75
	i32 126, ; 76
	i32 120, ; 77
	i32 146, ; 78
	i32 44, ; 79
	i32 3, ; 80
	i32 135, ; 81
	i32 56, ; 82
	i32 33, ; 83
	i32 104, ; 84
	i32 148, ; 85
	i32 117, ; 86
	i32 103, ; 87
	i32 28, ; 88
	i32 116, ; 89
	i32 160, ; 90
	i32 66, ; 91
	i32 89, ; 92
	i32 112, ; 93
	i32 124, ; 94
	i32 143, ; 95
	i32 18, ; 96
	i32 26, ; 97
	i32 100, ; 98
	i32 100, ; 99
	i32 143, ; 100
	i32 141, ; 101
	i32 107, ; 102
	i32 26, ; 103
	i32 29, ; 104
	i32 114, ; 105
	i32 152, ; 106
	i32 149, ; 107
	i32 45, ; 108
	i32 91, ; 109
	i32 113, ; 110
	i32 150, ; 111
	i32 23, ; 112
	i32 39, ; 113
	i32 136, ; 114
	i32 6, ; 115
	i32 34, ; 116
	i32 79, ; 117
	i32 7, ; 118
	i32 11, ; 119
	i32 69, ; 120
	i32 75, ; 121
	i32 54, ; 122
	i32 19, ; 123
	i32 110, ; 124
	i32 163, ; 125
	i32 161, ; 126
	i32 131, ; 127
	i32 42, ; 128
	i32 64, ; 129
	i32 134, ; 130
	i32 119, ; 131
	i32 140, ; 132
	i32 103, ; 133
	i32 161, ; 134
	i32 132, ; 135
	i32 109, ; 136
	i32 65, ; 137
	i32 121, ; 138
	i32 123, ; 139
	i32 166, ; 140
	i32 96, ; 141
	i32 93, ; 142
	i32 14, ; 143
	i32 68, ; 144
	i32 25, ; 145
	i32 101, ; 146
	i32 78, ; 147
	i32 108, ; 148
	i32 16, ; 149
	i32 138, ; 150
	i32 167, ; 151
	i32 101, ; 152
	i32 61, ; 153
	i32 109, ; 154
	i32 152, ; 155
	i32 31, ; 156
	i32 86, ; 157
	i32 137, ; 158
	i32 98, ; 159
	i32 133, ; 160
	i32 35, ; 161
	i32 167, ; 162
	i32 96, ; 163
	i32 85, ; 164
	i32 21, ; 165
	i32 40, ; 166
	i32 108, ; 167
	i32 163, ; 168
	i32 31, ; 169
	i32 46, ; 170
	i32 46, ; 171
	i32 91, ; 172
	i32 67, ; 173
	i32 5, ; 174
	i32 29, ; 175
	i32 155, ; 176
	i32 72, ; 177
	i32 99, ; 178
	i32 1, ; 179
	i32 169, ; 180
	i32 118, ; 181
	i32 59, ; 182
	i32 63, ; 183
	i32 121, ; 184
	i32 135, ; 185
	i32 57, ; 186
	i32 3, ; 187
	i32 40, ; 188
	i32 19, ; 189
	i32 38, ; 190
	i32 75, ; 191
	i32 128, ; 192
	i32 137, ; 193
	i32 154, ; 194
	i32 136, ; 195
	i32 94, ; 196
	i32 73, ; 197
	i32 47, ; 198
	i32 1, ; 199
	i32 33, ; 200
	i32 125, ; 201
	i32 118, ; 202
	i32 41, ; 203
	i32 35, ; 204
	i32 53, ; 205
	i32 59, ; 206
	i32 12, ; 207
	i32 27, ; 208
	i32 8, ; 209
	i32 90, ; 210
	i32 15, ; 211
	i32 54, ; 212
	i32 74, ; 213
	i32 142, ; 214
	i32 13, ; 215
	i32 90, ; 216
	i32 52, ; 217
	i32 165, ; 218
	i32 157, ; 219
	i32 30, ; 220
	i32 128, ; 221
	i32 138, ; 222
	i32 146, ; 223
	i32 98, ; 224
	i32 36, ; 225
	i32 43, ; 226
	i32 77, ; 227
	i32 82, ; 228
	i32 34, ; 229
	i32 110, ; 230
	i32 39, ; 231
	i32 70, ; 232
	i32 115, ; 233
	i32 71, ; 234
	i32 153, ; 235
	i32 42, ; 236
	i32 116, ; 237
	i32 55, ; 238
	i32 130, ; 239
	i32 43, ; 240
	i32 0, ; 241
	i32 21, ; 242
	i32 145, ; 243
	i32 168, ; 244
	i32 95, ; 245
	i32 9, ; 246
	i32 93, ; 247
	i32 30, ; 248
	i32 87, ; 249
	i32 102, ; 250
	i32 44, ; 251
	i32 105, ; 252
	i32 77, ; 253
	i32 70, ; 254
	i32 159, ; 255
	i32 153, ; 256
	i32 140, ; 257
	i32 151, ; 258
	i32 23, ; 259
	i32 126, ; 260
	i32 24, ; 261
	i32 32, ; 262
	i32 36, ; 263
	i32 150, ; 264
	i32 2, ; 265
	i32 145, ; 266
	i32 50, ; 267
	i32 160, ; 268
	i32 16, ; 269
	i32 15, ; 270
	i32 32, ; 271
	i32 148, ; 272
	i32 74, ; 273
	i32 0, ; 274
	i32 51, ; 275
	i32 130, ; 276
	i32 115, ; 277
	i32 127, ; 278
	i32 132, ; 279
	i32 17, ; 280
	i32 114, ; 281
	i32 119, ; 282
	i32 22, ; 283
	i32 49, ; 284
	i32 73, ; 285
	i32 51, ; 286
	i32 154, ; 287
	i32 105, ; 288
	i32 122, ; 289
	i32 4, ; 290
	i32 151, ; 291
	i32 129, ; 292
	i32 81, ; 293
	i32 164, ; 294
	i32 162, ; 295
	i32 5, ; 296
	i32 157, ; 297
	i32 56, ; 298
	i32 156, ; 299
	i32 24, ; 300
	i32 164, ; 301
	i32 127, ; 302
	i32 18, ; 303
	i32 53, ; 304
	i32 37, ; 305
	i32 61, ; 306
	i32 86, ; 307
	i32 17, ; 308
	i32 106, ; 309
	i32 155, ; 310
	i32 25, ; 311
	i32 41, ; 312
	i32 84, ; 313
	i32 99, ; 314
	i32 83, ; 315
	i32 102, ; 316
	i32 20, ; 317
	i32 134, ; 318
	i32 106, ; 319
	i32 10, ; 320
	i32 10, ; 321
	i32 8, ; 322
	i32 20, ; 323
	i32 107, ; 324
	i32 82, ; 325
	i32 80, ; 326
	i32 142, ; 327
	i32 63, ; 328
	i32 144, ; 329
	i32 11, ; 330
	i32 4, ; 331
	i32 159, ; 332
	i32 83, ; 333
	i32 113, ; 334
	i32 97, ; 335
	i32 85, ; 336
	i32 14, ; 337
	i32 13, ; 338
	i32 9 ; 339
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 8

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 8

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 8

; Functions

; Function attributes: "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 8, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 1

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+fix-cortex-a53-835769,+neon,+outline-atomics,+v8a" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+fix-cortex-a53-835769,+neon,+outline-atomics,+v8a" }

; Metadata
!llvm.module.flags = !{!0, !1, !7, !8, !9, !10}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.1xx @ af27162bee43b7fecdca59b4f67aa8c175cbc875"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"branch-target-enforcement", i32 0}
!8 = !{i32 1, !"sign-return-address", i32 0}
!9 = !{i32 1, !"sign-return-address-all", i32 0}
!10 = !{i32 1, !"sign-return-address-with-bkey", i32 0}
