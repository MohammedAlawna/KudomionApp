; ModuleID = 'marshal_methods.x86.ll'
source_filename = "marshal_methods.x86.ll"
target datalayout = "e-m:e-p:32:32-p270:32:32-p271:32:32-p272:64:64-f64:32:64-f80:32-n8:16:32-S128"
target triple = "i686-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [170 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [340 x i32] [
	i32 10166715, ; 0: System.Net.NameResolution.dll => 0x9b21bb => 124
	i32 38948123, ; 1: ar\Microsoft.Maui.Controls.resources.dll => 0x2524d1b => 0
	i32 39109920, ; 2: Newtonsoft.Json.dll => 0x254c520 => 62
	i32 42244203, ; 3: he\Microsoft.Maui.Controls.resources.dll => 0x284986b => 9
	i32 42639949, ; 4: System.Threading.Thread => 0x28aa24d => 158
	i32 67008169, ; 5: zh-Hant\Microsoft.Maui.Controls.resources => 0x3fe76a9 => 33
	i32 68219467, ; 6: System.Security.Cryptography.Primitives => 0x410f24b => 150
	i32 72070932, ; 7: Microsoft.Maui.Graphics.dll => 0x44bb714 => 61
	i32 83839681, ; 8: ms\Microsoft.Maui.Controls.resources.dll => 0x4ff4ac1 => 17
	i32 117431740, ; 9: System.Runtime.InteropServices => 0x6ffddbc => 142
	i32 136584136, ; 10: zh-Hans\Microsoft.Maui.Controls.resources.dll => 0x8241bc8 => 32
	i32 140062828, ; 11: sk\Microsoft.Maui.Controls.resources.dll => 0x859306c => 25
	i32 142721839, ; 12: System.Net.WebHeaderCollection => 0x881c32f => 130
	i32 149972175, ; 13: System.Security.Cryptography.Primitives.dll => 0x8f064cf => 150
	i32 165246403, ; 14: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 71
	i32 182336117, ; 15: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 89
	i32 205061960, ; 16: System.ComponentModel => 0xc38ff48 => 104
	i32 209399409, ; 17: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 69
	i32 220171995, ; 18: System.Diagnostics.Debug => 0xd1f8edb => 107
	i32 230752869, ; 19: Microsoft.CSharp.dll => 0xdc10265 => 96
	i32 246610117, ; 20: System.Reflection.Emit.Lightweight => 0xeb2f8c5 => 137
	i32 317674968, ; 21: vi\Microsoft.Maui.Controls.resources => 0x12ef55d8 => 30
	i32 318968648, ; 22: Xamarin.AndroidX.Activity.dll => 0x13031348 => 66
	i32 321963286, ; 23: fr\Microsoft.Maui.Controls.resources.dll => 0x1330c516 => 8
	i32 342366114, ; 24: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 78
	i32 367780167, ; 25: System.IO.Pipes => 0x15ebe147 => 116
	i32 375677976, ; 26: System.Net.ServicePoint.dll => 0x16646418 => 128
	i32 379916513, ; 27: System.Threading.Thread.dll => 0x16a510e1 => 158
	i32 385762202, ; 28: System.Memory.dll => 0x16fe439a => 120
	i32 393699800, ; 29: Firebase => 0x177761d8 => 40
	i32 395744057, ; 30: _Microsoft.Android.Resource.Designer => 0x17969339 => 34
	i32 409257351, ; 31: tr\Microsoft.Maui.Controls.resources.dll => 0x1864c587 => 28
	i32 442565967, ; 32: System.Collections => 0x1a61054f => 101
	i32 450948140, ; 33: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 77
	i32 451504562, ; 34: System.Security.Cryptography.X509Certificates => 0x1ae969b2 => 151
	i32 456227837, ; 35: System.Web.HttpUtility.dll => 0x1b317bfd => 160
	i32 459347974, ; 36: System.Runtime.Serialization.Primitives.dll => 0x1b611806 => 146
	i32 469710990, ; 37: System.dll => 0x1bff388e => 164
	i32 489220957, ; 38: es\Microsoft.Maui.Controls.resources.dll => 0x1d28eb5d => 6
	i32 498788369, ; 39: System.ObjectModel => 0x1dbae811 => 132
	i32 513247710, ; 40: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 55
	i32 530272170, ; 41: System.Linq.Queryable => 0x1f9b4faa => 118
	i32 538707440, ; 42: th\Microsoft.Maui.Controls.resources.dll => 0x201c05f0 => 27
	i32 539058512, ; 43: Microsoft.Extensions.Logging => 0x20216150 => 52
	i32 548916678, ; 44: Microsoft.Bcl.AsyncInterfaces => 0x20b7cdc6 => 47
	i32 597488923, ; 45: CommunityToolkit.Maui => 0x239cf51b => 35
	i32 610194910, ; 46: System.Reactive.dll => 0x245ed5de => 65
	i32 613668793, ; 47: System.Security.Cryptography.Algorithms => 0x2493d7b9 => 149
	i32 627609679, ; 48: Xamarin.AndroidX.CustomView => 0x2568904f => 75
	i32 627931235, ; 49: nl\Microsoft.Maui.Controls.resources => 0x256d7863 => 19
	i32 672442732, ; 50: System.Collections.Concurrent => 0x2814a96c => 97
	i32 683518922, ; 51: System.Net.Security => 0x28bdabca => 127
	i32 690569205, ; 52: System.Xml.Linq.dll => 0x29293ff5 => 161
	i32 722857257, ; 53: System.Runtime.Loader.dll => 0x2b15ed29 => 143
	i32 759454413, ; 54: System.Net.Requests => 0x2d445acd => 126
	i32 762598435, ; 55: System.IO.Pipes.dll => 0x2d745423 => 116
	i32 775507847, ; 56: System.IO.Compression => 0x2e394f87 => 115
	i32 777317022, ; 57: sk\Microsoft.Maui.Controls.resources => 0x2e54ea9e => 25
	i32 789151979, ; 58: Microsoft.Extensions.Options => 0x2f0980eb => 54
	i32 804715423, ; 59: System.Data.Common => 0x2ff6fb9f => 106
	i32 823281589, ; 60: System.Private.Uri.dll => 0x311247b5 => 133
	i32 830298997, ; 61: System.IO.Compression.Brotli => 0x317d5b75 => 114
	i32 869139383, ; 62: hi\Microsoft.Maui.Controls.resources.dll => 0x33ce03b7 => 10
	i32 880668424, ; 63: ru\Microsoft.Maui.Controls.resources.dll => 0x347def08 => 24
	i32 904024072, ; 64: System.ComponentModel.Primitives.dll => 0x35e25008 => 102
	i32 918734561, ; 65: pt-BR\Microsoft.Maui.Controls.resources.dll => 0x36c2c6e1 => 21
	i32 955402788, ; 66: Newtonsoft.Json => 0x38f24a24 => 62
	i32 961460050, ; 67: it\Microsoft.Maui.Controls.resources.dll => 0x394eb752 => 14
	i32 967690846, ; 68: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 78
	i32 975874589, ; 69: System.Xml.XDocument => 0x3a2aaa1d => 163
	i32 990727110, ; 70: ro\Microsoft.Maui.Controls.resources.dll => 0x3b0d4bc6 => 23
	i32 992768348, ; 71: System.Collections.dll => 0x3b2c715c => 101
	i32 1012816738, ; 72: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 88
	i32 1019214401, ; 73: System.Drawing => 0x3cbffa41 => 112
	i32 1028951442, ; 74: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 51
	i32 1035644815, ; 75: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 67
	i32 1036536393, ; 76: System.Drawing.Primitives.dll => 0x3dc84a49 => 111
	i32 1043950537, ; 77: de\Microsoft.Maui.Controls.resources.dll => 0x3e396bc9 => 4
	i32 1044663988, ; 78: System.Linq.Expressions.dll => 0x3e444eb4 => 117
	i32 1052210849, ; 79: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 80
	i32 1082857460, ; 80: System.ComponentModel.TypeConverter => 0x408b17f4 => 103
	i32 1084122840, ; 81: Xamarin.Kotlin.StdLib => 0x409e66d8 => 93
	i32 1098259244, ; 82: System => 0x41761b2c => 164
	i32 1108272742, ; 83: sv\Microsoft.Maui.Controls.resources.dll => 0x420ee666 => 26
	i32 1117529484, ; 84: pl\Microsoft.Maui.Controls.resources.dll => 0x429c258c => 20
	i32 1118262833, ; 85: ko\Microsoft.Maui.Controls.resources => 0x42a75631 => 16
	i32 1168523401, ; 86: pt\Microsoft.Maui.Controls.resources => 0x45a64089 => 22
	i32 1178241025, ; 87: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 85
	i32 1208641965, ; 88: System.Diagnostics.Process => 0x480a69ad => 109
	i32 1214827643, ; 89: CommunityToolkit.Mvvm => 0x4868cc7b => 37
	i32 1260983243, ; 90: cs\Microsoft.Maui.Controls.resources => 0x4b2913cb => 2
	i32 1293217323, ; 91: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 76
	i32 1308624726, ; 92: hr\Microsoft.Maui.Controls.resources.dll => 0x4e000756 => 11
	i32 1324164729, ; 93: System.Linq => 0x4eed2679 => 119
	i32 1336711579, ; 94: zh-HK\Microsoft.Maui.Controls.resources.dll => 0x4fac999b => 31
	i32 1373134921, ; 95: zh-Hans\Microsoft.Maui.Controls.resources => 0x51d86049 => 32
	i32 1376866003, ; 96: Xamarin.AndroidX.SavedState => 0x52114ed3 => 88
	i32 1406073936, ; 97: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 72
	i32 1408764838, ; 98: System.Runtime.Serialization.Formatters.dll => 0x53f80ba6 => 145
	i32 1430672901, ; 99: ar\Microsoft.Maui.Controls.resources => 0x55465605 => 0
	i32 1452070440, ; 100: System.Formats.Asn1.dll => 0x568cd628 => 113
	i32 1458022317, ; 101: System.Net.Security.dll => 0x56e7a7ad => 127
	i32 1461004990, ; 102: es\Microsoft.Maui.Controls.resources => 0x57152abe => 6
	i32 1461234159, ; 103: System.Collections.Immutable.dll => 0x5718a9ef => 98
	i32 1462112819, ; 104: System.IO.Compression.dll => 0x57261233 => 115
	i32 1469204771, ; 105: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 68
	i32 1470490898, ; 106: Microsoft.Extensions.Primitives => 0x57a5e912 => 55
	i32 1479771757, ; 107: System.Collections.Immutable => 0x5833866d => 98
	i32 1480492111, ; 108: System.IO.Compression.Brotli.dll => 0x583e844f => 114
	i32 1526286932, ; 109: vi\Microsoft.Maui.Controls.resources.dll => 0x5af94a54 => 30
	i32 1543031311, ; 110: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 155
	i32 1550322496, ; 111: System.Reflection.Extensions.dll => 0x5c680b40 => 138
	i32 1622152042, ; 112: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 82
	i32 1624863272, ; 113: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 91
	i32 1634654947, ; 114: CommunityToolkit.Maui.Core.dll => 0x616edae3 => 36
	i32 1636350590, ; 115: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 74
	i32 1639515021, ; 116: System.Net.Http.dll => 0x61b9038d => 121
	i32 1639986890, ; 117: System.Text.RegularExpressions => 0x61c036ca => 155
	i32 1657153582, ; 118: System.Runtime => 0x62c6282e => 147
	i32 1658251792, ; 119: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 92
	i32 1677501392, ; 120: System.Net.Primitives.dll => 0x63fca3d0 => 125
	i32 1679769178, ; 121: System.Security.Cryptography => 0x641f3e5a => 152
	i32 1701541528, ; 122: System.Diagnostics.Debug.dll => 0x656b7698 => 107
	i32 1726116996, ; 123: System.Reflection.dll => 0x66e27484 => 140
	i32 1729485958, ; 124: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 70
	i32 1743415430, ; 125: ca\Microsoft.Maui.Controls.resources => 0x67ea6886 => 1
	i32 1763938596, ; 126: System.Diagnostics.TraceSource.dll => 0x69239124 => 110
	i32 1765942094, ; 127: System.Reflection.Extensions => 0x6942234e => 138
	i32 1766324549, ; 128: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 89
	i32 1770582343, ; 129: Microsoft.Extensions.Logging.dll => 0x6988f147 => 52
	i32 1780572499, ; 130: Mono.Android.Runtime.dll => 0x6a216153 => 168
	i32 1782862114, ; 131: ms\Microsoft.Maui.Controls.resources => 0x6a445122 => 17
	i32 1788241197, ; 132: Xamarin.AndroidX.Fragment => 0x6a96652d => 77
	i32 1793755602, ; 133: he\Microsoft.Maui.Controls.resources => 0x6aea89d2 => 9
	i32 1796167890, ; 134: Microsoft.Bcl.AsyncInterfaces.dll => 0x6b0f58d2 => 47
	i32 1808609942, ; 135: Xamarin.AndroidX.Loader => 0x6bcd3296 => 82
	i32 1813058853, ; 136: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 93
	i32 1813201214, ; 137: Xamarin.Google.Android.Material => 0x6c13413e => 92
	i32 1818569960, ; 138: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 86
	i32 1824175904, ; 139: System.Text.Encoding.Extensions => 0x6cbab720 => 153
	i32 1824722060, ; 140: System.Runtime.Serialization.Formatters => 0x6cc30c8c => 145
	i32 1828688058, ; 141: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 53
	i32 1853025655, ; 142: sv\Microsoft.Maui.Controls.resources => 0x6e72ed77 => 26
	i32 1858542181, ; 143: System.Linq.Expressions => 0x6ec71a65 => 117
	i32 1870277092, ; 144: System.Reflection.Primitives => 0x6f7a29e4 => 139
	i32 1875935024, ; 145: fr\Microsoft.Maui.Controls.resources => 0x6fd07f30 => 8
	i32 1893218855, ; 146: cs\Microsoft.Maui.Controls.resources.dll => 0x70d83a27 => 2
	i32 1910275211, ; 147: System.Collections.NonGeneric.dll => 0x71dc7c8b => 99
	i32 1927897671, ; 148: System.CodeDom.dll => 0x72e96247 => 63
	i32 1939592360, ; 149: System.Private.Xml.Linq => 0x739bd4a8 => 134
	i32 1953182387, ; 150: id\Microsoft.Maui.Controls.resources.dll => 0x746b32b3 => 13
	i32 1968388702, ; 151: Microsoft.Extensions.Configuration.dll => 0x75533a5e => 48
	i32 2001273273, ; 152: KudomionApp => 0x774901b9 => 95
	i32 2003115576, ; 153: el\Microsoft.Maui.Controls.resources => 0x77651e38 => 5
	i32 2019465201, ; 154: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 80
	i32 2045470958, ; 155: System.Private.Xml => 0x79eb68ee => 135
	i32 2055257422, ; 156: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 79
	i32 2066184531, ; 157: de\Microsoft.Maui.Controls.resources => 0x7b277953 => 4
	i32 2070888862, ; 158: System.Diagnostics.TraceSource => 0x7b6f419e => 110
	i32 2079903147, ; 159: System.Runtime.dll => 0x7bf8cdab => 147
	i32 2090596640, ; 160: System.Numerics.Vectors => 0x7c9bf920 => 131
	i32 2127167465, ; 161: System.Console => 0x7ec9ffe9 => 105
	i32 2142473426, ; 162: System.Collections.Specialized => 0x7fb38cd2 => 100
	i32 2159891885, ; 163: Microsoft.Maui => 0x80bd55ad => 59
	i32 2169148018, ; 164: hu\Microsoft.Maui.Controls.resources => 0x814a9272 => 12
	i32 2178612968, ; 165: System.CodeDom => 0x81dafee8 => 63
	i32 2181898931, ; 166: Microsoft.Extensions.Options.dll => 0x820d22b3 => 54
	i32 2192057212, ; 167: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 53
	i32 2193016926, ; 168: System.ObjectModel.dll => 0x82b6c85e => 132
	i32 2201107256, ; 169: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 94
	i32 2201231467, ; 170: System.Net.Http => 0x8334206b => 121
	i32 2207618523, ; 171: it\Microsoft.Maui.Controls.resources => 0x839595db => 14
	i32 2216717168, ; 172: Firebase.Auth.dll => 0x84206b70 => 39
	i32 2266799131, ; 173: Microsoft.Extensions.Configuration.Abstractions => 0x871c9c1b => 49
	i32 2279755925, ; 174: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 87
	i32 2295906218, ; 175: System.Net.Sockets => 0x88d8bfaa => 129
	i32 2298471582, ; 176: System.Net.Mail => 0x88ffe49e => 123
	i32 2303942373, ; 177: nb\Microsoft.Maui.Controls.resources => 0x89535ee5 => 18
	i32 2305521784, ; 178: System.Private.CoreLib.dll => 0x896b7878 => 166
	i32 2340441535, ; 179: System.Runtime.InteropServices.RuntimeInformation.dll => 0x8b804dbf => 141
	i32 2353062107, ; 180: System.Net.Primitives => 0x8c40e0db => 125
	i32 2366048013, ; 181: hu\Microsoft.Maui.Controls.resources.dll => 0x8d07070d => 12
	i32 2368005991, ; 182: System.Xml.ReaderWriter.dll => 0x8d24e767 => 162
	i32 2371007202, ; 183: Microsoft.Extensions.Configuration => 0x8d52b2e2 => 48
	i32 2395872292, ; 184: id\Microsoft.Maui.Controls.resources => 0x8ece1c24 => 13
	i32 2401565422, ; 185: System.Web.HttpUtility => 0x8f24faee => 160
	i32 2409752120, ; 186: KudomionApp.dll => 0x8fa1e638 => 95
	i32 2427813419, ; 187: hi\Microsoft.Maui.Controls.resources => 0x90b57e2b => 10
	i32 2435356389, ; 188: System.Console.dll => 0x912896e5 => 105
	i32 2454642406, ; 189: System.Text.Encoding.dll => 0x924edee6 => 154
	i32 2458678730, ; 190: System.Net.Sockets.dll => 0x928c75ca => 129
	i32 2471841756, ; 191: netstandard.dll => 0x93554fdc => 165
	i32 2475788418, ; 192: Java.Interop.dll => 0x93918882 => 167
	i32 2480646305, ; 193: Microsoft.Maui.Controls => 0x93dba8a1 => 57
	i32 2484371297, ; 194: System.Net.ServicePoint => 0x94147f61 => 128
	i32 2486847491, ; 195: Google.Api.Gax => 0x943a4803 => 41
	i32 2503351294, ; 196: ko\Microsoft.Maui.Controls.resources.dll => 0x95361bfe => 16
	i32 2538310050, ; 197: System.Reflection.Emit.Lightweight.dll => 0x974b89a2 => 137
	i32 2550873716, ; 198: hr\Microsoft.Maui.Controls.resources => 0x980b3e74 => 11
	i32 2562349572, ; 199: Microsoft.CSharp => 0x98ba5a04 => 96
	i32 2576534780, ; 200: ja\Microsoft.Maui.Controls.resources.dll => 0x9992ccfc => 15
	i32 2585220780, ; 201: System.Text.Encoding.Extensions.dll => 0x9a1756ac => 153
	i32 2593496499, ; 202: pl\Microsoft.Maui.Controls.resources => 0x9a959db3 => 20
	i32 2595928349, ; 203: FirebaseAdmin => 0x9abab91d => 38
	i32 2605712449, ; 204: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 94
	i32 2617129537, ; 205: System.Private.Xml.dll => 0x9bfe3a41 => 135
	i32 2620871830, ; 206: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 74
	i32 2626831493, ; 207: ja\Microsoft.Maui.Controls.resources => 0x9c924485 => 15
	i32 2629053246, ; 208: Google.Api.Gax.Rest => 0x9cb42b3e => 42
	i32 2663698177, ; 209: System.Runtime.Loader => 0x9ec4cf01 => 143
	i32 2664396074, ; 210: System.Xml.XDocument.dll => 0x9ecf752a => 163
	i32 2665622720, ; 211: System.Drawing.Primitives => 0x9ee22cc0 => 111
	i32 2676780864, ; 212: System.Data.Common.dll => 0x9f8c6f40 => 106
	i32 2715334215, ; 213: System.Threading.Tasks.dll => 0xa1d8b647 => 157
	i32 2717744543, ; 214: System.Security.Claims => 0xa1fd7d9f => 148
	i32 2724373263, ; 215: System.Runtime.Numerics.dll => 0xa262a30f => 144
	i32 2732626843, ; 216: Xamarin.AndroidX.Activity => 0xa2e0939b => 66
	i32 2737747696, ; 217: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 68
	i32 2740698338, ; 218: ca\Microsoft.Maui.Controls.resources.dll => 0xa35bbce2 => 1
	i32 2752995522, ; 219: pt-BR\Microsoft.Maui.Controls.resources => 0xa41760c2 => 21
	i32 2758225723, ; 220: Microsoft.Maui.Controls.Xaml => 0xa4672f3b => 58
	i32 2764765095, ; 221: Microsoft.Maui.dll => 0xa4caf7a7 => 59
	i32 2778768386, ; 222: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 90
	i32 2785988530, ; 223: th\Microsoft.Maui.Controls.resources => 0xa60ecfb2 => 27
	i32 2801831435, ; 224: Microsoft.Maui.Graphics => 0xa7008e0b => 61
	i32 2810250172, ; 225: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 72
	i32 2853208004, ; 226: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 90
	i32 2861189240, ; 227: Microsoft.Maui.Essentials => 0xaa8a4878 => 60
	i32 2868488919, ; 228: CommunityToolkit.Maui.Core => 0xaaf9aad7 => 36
	i32 2893550578, ; 229: Google.Apis.Core => 0xac7813f2 => 45
	i32 2898407901, ; 230: System.Management => 0xacc231dd => 64
	i32 2901442782, ; 231: System.Reflection => 0xacf080de => 140
	i32 2909740682, ; 232: System.Private.CoreLib => 0xad6f1e8a => 166
	i32 2916838712, ; 233: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 91
	i32 2919462931, ; 234: System.Numerics.Vectors.dll => 0xae037813 => 131
	i32 2959614098, ; 235: System.ComponentModel.dll => 0xb0682092 => 104
	i32 2972252294, ; 236: System.Security.Cryptography.Algorithms.dll => 0xb128f886 => 149
	i32 2978675010, ; 237: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 76
	i32 2990604888, ; 238: Google.Apis => 0xb2410258 => 43
	i32 3038032645, ; 239: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 34
	i32 3053864966, ; 240: fi\Microsoft.Maui.Controls.resources.dll => 0xb6064806 => 7
	i32 3057625584, ; 241: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 83
	i32 3059408633, ; 242: Mono.Android.Runtime => 0xb65adef9 => 168
	i32 3059793426, ; 243: System.ComponentModel.Primitives => 0xb660be12 => 102
	i32 3075834255, ; 244: System.Threading.Tasks => 0xb755818f => 157
	i32 3090735792, ; 245: System.Security.Cryptography.X509Certificates.dll => 0xb838e2b0 => 151
	i32 3099732863, ; 246: System.Security.Claims.dll => 0xb8c22b7f => 148
	i32 3103600923, ; 247: System.Formats.Asn1 => 0xb8fd311b => 113
	i32 3124832203, ; 248: System.Threading.Tasks.Extensions => 0xba4127cb => 156
	i32 3159123045, ; 249: System.Reflection.Primitives.dll => 0xbc4c6465 => 139
	i32 3178803400, ; 250: Xamarin.AndroidX.Navigation.Fragment.dll => 0xbd78b0c8 => 84
	i32 3203277885, ; 251: Google.Api.Gax.dll => 0xbeee243d => 41
	i32 3220365878, ; 252: System.Threading => 0xbff2e236 => 159
	i32 3258312781, ; 253: Xamarin.AndroidX.CardView => 0xc235e84d => 70
	i32 3265493905, ; 254: System.Linq.Queryable.dll => 0xc2a37b91 => 118
	i32 3265893370, ; 255: System.Threading.Tasks.Extensions.dll => 0xc2a993fa => 156
	i32 3299363146, ; 256: System.Text.Encoding => 0xc4a8494a => 154
	i32 3305363605, ; 257: fi\Microsoft.Maui.Controls.resources => 0xc503d895 => 7
	i32 3316684772, ; 258: System.Net.Requests.dll => 0xc5b097e4 => 126
	i32 3317135071, ; 259: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 75
	i32 3322403133, ; 260: Firebase.dll => 0xc607d93d => 40
	i32 3346324047, ; 261: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 85
	i32 3357674450, ; 262: ru\Microsoft.Maui.Controls.resources => 0xc8220bd2 => 24
	i32 3362522851, ; 263: Xamarin.AndroidX.Core => 0xc86c06e3 => 73
	i32 3366347497, ; 264: Java.Interop => 0xc8a662e9 => 167
	i32 3374999561, ; 265: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 87
	i32 3381016424, ; 266: da\Microsoft.Maui.Controls.resources => 0xc9863768 => 3
	i32 3428513518, ; 267: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 50
	i32 3430777524, ; 268: netstandard => 0xcc7d82b4 => 165
	i32 3452344032, ; 269: Microsoft.Maui.Controls.Compatibility.dll => 0xcdc696e0 => 56
	i32 3453592554, ; 270: Google.Apis.Core.dll => 0xcdd9a3ea => 45
	i32 3458724246, ; 271: pt\Microsoft.Maui.Controls.resources.dll => 0xce27f196 => 22
	i32 3471940407, ; 272: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 103
	i32 3476120550, ; 273: Mono.Android => 0xcf3163e6 => 169
	i32 3484440000, ; 274: ro\Microsoft.Maui.Controls.resources => 0xcfb055c0 => 23
	i32 3509114376, ; 275: System.Xml.Linq => 0xd128d608 => 161
	i32 3539954161, ; 276: System.Net.HttpListener => 0xd2ff69f1 => 122
	i32 3580758918, ; 277: zh-HK\Microsoft.Maui.Controls.resources => 0xd56e0b86 => 31
	i32 3592228221, ; 278: zh-Hant\Microsoft.Maui.Controls.resources.dll => 0xd61d0d7d => 33
	i32 3596207933, ; 279: LiteDB.dll => 0xd659c73d => 46
	i32 3608519521, ; 280: System.Linq.dll => 0xd715a361 => 119
	i32 3612435020, ; 281: System.Management.dll => 0xd751624c => 64
	i32 3621458322, ; 282: Google.Api.Gax.Rest.dll => 0xd7db1192 => 42
	i32 3624195450, ; 283: System.Runtime.InteropServices.RuntimeInformation => 0xd804d57a => 141
	i32 3629588173, ; 284: LiteDB => 0xd8571ecd => 46
	i32 3641597786, ; 285: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 79
	i32 3643446276, ; 286: tr\Microsoft.Maui.Controls.resources => 0xd92a9404 => 28
	i32 3643854240, ; 287: Xamarin.AndroidX.Navigation.Fragment => 0xd930cda0 => 84
	i32 3657292374, ; 288: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd9fdda56 => 49
	i32 3672681054, ; 289: Mono.Android.dll => 0xdae8aa5e => 169
	i32 3682565725, ; 290: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 69
	i32 3724971120, ; 291: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 83
	i32 3731644420, ; 292: System.Reactive => 0xde6c6004 => 65
	i32 3732100267, ; 293: System.Net.NameResolution => 0xde7354ab => 124
	i32 3748608112, ; 294: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 108
	i32 3751619990, ; 295: da\Microsoft.Maui.Controls.resources.dll => 0xdf9d2d96 => 3
	i32 3786282454, ; 296: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 71
	i32 3792276235, ; 297: System.Collections.NonGeneric => 0xe2098b0b => 99
	i32 3793997468, ; 298: Google.Apis.Auth.dll => 0xe223ce9c => 44
	i32 3800979733, ; 299: Microsoft.Maui.Controls.Compatibility => 0xe28e5915 => 56
	i32 3802395368, ; 300: System.Collections.Specialized.dll => 0xe2a3f2e8 => 100
	i32 3817368567, ; 301: CommunityToolkit.Maui.dll => 0xe3886bf7 => 35
	i32 3823082795, ; 302: System.Security.Cryptography.dll => 0xe3df9d2b => 152
	i32 3841636137, ; 303: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 51
	i32 3844307129, ; 304: System.Net.Mail.dll => 0xe52378b9 => 123
	i32 3849253459, ; 305: System.Runtime.InteropServices.dll => 0xe56ef253 => 142
	i32 3870376305, ; 306: System.Net.HttpListener.dll => 0xe6b14171 => 122
	i32 3885497537, ; 307: System.Net.WebHeaderCollection.dll => 0xe797fcc1 => 130
	i32 3896106733, ; 308: System.Collections.Concurrent.dll => 0xe839deed => 97
	i32 3896760992, ; 309: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 73
	i32 3920221145, ; 310: nl\Microsoft.Maui.Controls.resources.dll => 0xe9a9d3d9 => 19
	i32 3928044579, ; 311: System.Xml.ReaderWriter => 0xea213423 => 162
	i32 3931092270, ; 312: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 86
	i32 3955647286, ; 313: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 67
	i32 4003436829, ; 314: System.Diagnostics.Process.dll => 0xee9f991d => 109
	i32 4024013275, ; 315: Firebase.Auth => 0xefd991db => 39
	i32 4025784931, ; 316: System.Memory => 0xeff49a63 => 120
	i32 4046471985, ; 317: Microsoft.Maui.Controls.Xaml.dll => 0xf1304331 => 58
	i32 4054681211, ; 318: System.Reflection.Emit.ILGeneration => 0xf1ad867b => 136
	i32 4059682726, ; 319: Google.Apis.dll => 0xf1f9d7a6 => 43
	i32 4068434129, ; 320: System.Private.Xml.Linq.dll => 0xf27f60d1 => 134
	i32 4073602200, ; 321: System.Threading.dll => 0xf2ce3c98 => 159
	i32 4082882467, ; 322: Google.Apis.Auth => 0xf35bd7a3 => 44
	i32 4091086043, ; 323: el\Microsoft.Maui.Controls.resources.dll => 0xf3d904db => 5
	i32 4094352644, ; 324: Microsoft.Maui.Essentials.dll => 0xf40add04 => 60
	i32 4099507663, ; 325: System.Drawing.dll => 0xf45985cf => 112
	i32 4100113165, ; 326: System.Private.Uri => 0xf462c30d => 133
	i32 4103439459, ; 327: uk\Microsoft.Maui.Controls.resources.dll => 0xf4958463 => 29
	i32 4126470640, ; 328: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 50
	i32 4147896353, ; 329: System.Reflection.Emit.ILGeneration.dll => 0xf73be021 => 136
	i32 4150914736, ; 330: uk\Microsoft.Maui.Controls.resources => 0xf769eeb0 => 29
	i32 4177102269, ; 331: FirebaseAdmin.dll => 0xf8f985bd => 38
	i32 4181436372, ; 332: System.Runtime.Serialization.Primitives => 0xf93ba7d4 => 146
	i32 4182413190, ; 333: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 81
	i32 4213026141, ; 334: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 108
	i32 4249188766, ; 335: nb\Microsoft.Maui.Controls.resources.dll => 0xfd45799e => 18
	i32 4271975918, ; 336: Microsoft.Maui.Controls.dll => 0xfea12dee => 57
	i32 4274623895, ; 337: CommunityToolkit.Mvvm.dll => 0xfec99597 => 37
	i32 4274976490, ; 338: System.Runtime.Numerics => 0xfecef6ea => 144
	i32 4292120959 ; 339: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 81
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [340 x i32] [
	i32 124, ; 0
	i32 0, ; 1
	i32 62, ; 2
	i32 9, ; 3
	i32 158, ; 4
	i32 33, ; 5
	i32 150, ; 6
	i32 61, ; 7
	i32 17, ; 8
	i32 142, ; 9
	i32 32, ; 10
	i32 25, ; 11
	i32 130, ; 12
	i32 150, ; 13
	i32 71, ; 14
	i32 89, ; 15
	i32 104, ; 16
	i32 69, ; 17
	i32 107, ; 18
	i32 96, ; 19
	i32 137, ; 20
	i32 30, ; 21
	i32 66, ; 22
	i32 8, ; 23
	i32 78, ; 24
	i32 116, ; 25
	i32 128, ; 26
	i32 158, ; 27
	i32 120, ; 28
	i32 40, ; 29
	i32 34, ; 30
	i32 28, ; 31
	i32 101, ; 32
	i32 77, ; 33
	i32 151, ; 34
	i32 160, ; 35
	i32 146, ; 36
	i32 164, ; 37
	i32 6, ; 38
	i32 132, ; 39
	i32 55, ; 40
	i32 118, ; 41
	i32 27, ; 42
	i32 52, ; 43
	i32 47, ; 44
	i32 35, ; 45
	i32 65, ; 46
	i32 149, ; 47
	i32 75, ; 48
	i32 19, ; 49
	i32 97, ; 50
	i32 127, ; 51
	i32 161, ; 52
	i32 143, ; 53
	i32 126, ; 54
	i32 116, ; 55
	i32 115, ; 56
	i32 25, ; 57
	i32 54, ; 58
	i32 106, ; 59
	i32 133, ; 60
	i32 114, ; 61
	i32 10, ; 62
	i32 24, ; 63
	i32 102, ; 64
	i32 21, ; 65
	i32 62, ; 66
	i32 14, ; 67
	i32 78, ; 68
	i32 163, ; 69
	i32 23, ; 70
	i32 101, ; 71
	i32 88, ; 72
	i32 112, ; 73
	i32 51, ; 74
	i32 67, ; 75
	i32 111, ; 76
	i32 4, ; 77
	i32 117, ; 78
	i32 80, ; 79
	i32 103, ; 80
	i32 93, ; 81
	i32 164, ; 82
	i32 26, ; 83
	i32 20, ; 84
	i32 16, ; 85
	i32 22, ; 86
	i32 85, ; 87
	i32 109, ; 88
	i32 37, ; 89
	i32 2, ; 90
	i32 76, ; 91
	i32 11, ; 92
	i32 119, ; 93
	i32 31, ; 94
	i32 32, ; 95
	i32 88, ; 96
	i32 72, ; 97
	i32 145, ; 98
	i32 0, ; 99
	i32 113, ; 100
	i32 127, ; 101
	i32 6, ; 102
	i32 98, ; 103
	i32 115, ; 104
	i32 68, ; 105
	i32 55, ; 106
	i32 98, ; 107
	i32 114, ; 108
	i32 30, ; 109
	i32 155, ; 110
	i32 138, ; 111
	i32 82, ; 112
	i32 91, ; 113
	i32 36, ; 114
	i32 74, ; 115
	i32 121, ; 116
	i32 155, ; 117
	i32 147, ; 118
	i32 92, ; 119
	i32 125, ; 120
	i32 152, ; 121
	i32 107, ; 122
	i32 140, ; 123
	i32 70, ; 124
	i32 1, ; 125
	i32 110, ; 126
	i32 138, ; 127
	i32 89, ; 128
	i32 52, ; 129
	i32 168, ; 130
	i32 17, ; 131
	i32 77, ; 132
	i32 9, ; 133
	i32 47, ; 134
	i32 82, ; 135
	i32 93, ; 136
	i32 92, ; 137
	i32 86, ; 138
	i32 153, ; 139
	i32 145, ; 140
	i32 53, ; 141
	i32 26, ; 142
	i32 117, ; 143
	i32 139, ; 144
	i32 8, ; 145
	i32 2, ; 146
	i32 99, ; 147
	i32 63, ; 148
	i32 134, ; 149
	i32 13, ; 150
	i32 48, ; 151
	i32 95, ; 152
	i32 5, ; 153
	i32 80, ; 154
	i32 135, ; 155
	i32 79, ; 156
	i32 4, ; 157
	i32 110, ; 158
	i32 147, ; 159
	i32 131, ; 160
	i32 105, ; 161
	i32 100, ; 162
	i32 59, ; 163
	i32 12, ; 164
	i32 63, ; 165
	i32 54, ; 166
	i32 53, ; 167
	i32 132, ; 168
	i32 94, ; 169
	i32 121, ; 170
	i32 14, ; 171
	i32 39, ; 172
	i32 49, ; 173
	i32 87, ; 174
	i32 129, ; 175
	i32 123, ; 176
	i32 18, ; 177
	i32 166, ; 178
	i32 141, ; 179
	i32 125, ; 180
	i32 12, ; 181
	i32 162, ; 182
	i32 48, ; 183
	i32 13, ; 184
	i32 160, ; 185
	i32 95, ; 186
	i32 10, ; 187
	i32 105, ; 188
	i32 154, ; 189
	i32 129, ; 190
	i32 165, ; 191
	i32 167, ; 192
	i32 57, ; 193
	i32 128, ; 194
	i32 41, ; 195
	i32 16, ; 196
	i32 137, ; 197
	i32 11, ; 198
	i32 96, ; 199
	i32 15, ; 200
	i32 153, ; 201
	i32 20, ; 202
	i32 38, ; 203
	i32 94, ; 204
	i32 135, ; 205
	i32 74, ; 206
	i32 15, ; 207
	i32 42, ; 208
	i32 143, ; 209
	i32 163, ; 210
	i32 111, ; 211
	i32 106, ; 212
	i32 157, ; 213
	i32 148, ; 214
	i32 144, ; 215
	i32 66, ; 216
	i32 68, ; 217
	i32 1, ; 218
	i32 21, ; 219
	i32 58, ; 220
	i32 59, ; 221
	i32 90, ; 222
	i32 27, ; 223
	i32 61, ; 224
	i32 72, ; 225
	i32 90, ; 226
	i32 60, ; 227
	i32 36, ; 228
	i32 45, ; 229
	i32 64, ; 230
	i32 140, ; 231
	i32 166, ; 232
	i32 91, ; 233
	i32 131, ; 234
	i32 104, ; 235
	i32 149, ; 236
	i32 76, ; 237
	i32 43, ; 238
	i32 34, ; 239
	i32 7, ; 240
	i32 83, ; 241
	i32 168, ; 242
	i32 102, ; 243
	i32 157, ; 244
	i32 151, ; 245
	i32 148, ; 246
	i32 113, ; 247
	i32 156, ; 248
	i32 139, ; 249
	i32 84, ; 250
	i32 41, ; 251
	i32 159, ; 252
	i32 70, ; 253
	i32 118, ; 254
	i32 156, ; 255
	i32 154, ; 256
	i32 7, ; 257
	i32 126, ; 258
	i32 75, ; 259
	i32 40, ; 260
	i32 85, ; 261
	i32 24, ; 262
	i32 73, ; 263
	i32 167, ; 264
	i32 87, ; 265
	i32 3, ; 266
	i32 50, ; 267
	i32 165, ; 268
	i32 56, ; 269
	i32 45, ; 270
	i32 22, ; 271
	i32 103, ; 272
	i32 169, ; 273
	i32 23, ; 274
	i32 161, ; 275
	i32 122, ; 276
	i32 31, ; 277
	i32 33, ; 278
	i32 46, ; 279
	i32 119, ; 280
	i32 64, ; 281
	i32 42, ; 282
	i32 141, ; 283
	i32 46, ; 284
	i32 79, ; 285
	i32 28, ; 286
	i32 84, ; 287
	i32 49, ; 288
	i32 169, ; 289
	i32 69, ; 290
	i32 83, ; 291
	i32 65, ; 292
	i32 124, ; 293
	i32 108, ; 294
	i32 3, ; 295
	i32 71, ; 296
	i32 99, ; 297
	i32 44, ; 298
	i32 56, ; 299
	i32 100, ; 300
	i32 35, ; 301
	i32 152, ; 302
	i32 51, ; 303
	i32 123, ; 304
	i32 142, ; 305
	i32 122, ; 306
	i32 130, ; 307
	i32 97, ; 308
	i32 73, ; 309
	i32 19, ; 310
	i32 162, ; 311
	i32 86, ; 312
	i32 67, ; 313
	i32 109, ; 314
	i32 39, ; 315
	i32 120, ; 316
	i32 58, ; 317
	i32 136, ; 318
	i32 43, ; 319
	i32 134, ; 320
	i32 159, ; 321
	i32 44, ; 322
	i32 5, ; 323
	i32 60, ; 324
	i32 112, ; 325
	i32 133, ; 326
	i32 29, ; 327
	i32 50, ; 328
	i32 136, ; 329
	i32 29, ; 330
	i32 38, ; 331
	i32 146, ; 332
	i32 81, ; 333
	i32 108, ; 334
	i32 18, ; 335
	i32 57, ; 336
	i32 37, ; 337
	i32 144, ; 338
	i32 81 ; 339
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 4

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 4

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 4

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
	store ptr %fn, ptr @get_function_pointer, align 4, !tbaa !3
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
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" }

; Metadata
!llvm.module.flags = !{!0, !1, !7}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.1xx @ af27162bee43b7fecdca59b4f67aa8c175cbc875"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"NumRegisterParameters", i32 0}
