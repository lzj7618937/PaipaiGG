# C#目录说明
+ Bin 目录用来存放编译的结果，bin是二进制binrary的英文缩写，因为最初C编译的程序文件都是二进制文件，它有Debug和Release两个版本，分别对应的文件夹为bin/Debug和bin/Release，这个文件夹是默认的输出路径，我们可以通过：项目属性—>配置属性—>输出路径来修改。
+ obj是object的缩写，用于存放编译过程中生成的中间临时文件。其中都有debug和release两个子目录，分别对应调试版本和发行版本，在.NET中，编译是分模块进行的，编译整个完成后会合并为一个.DLL或.EXE保存到bin目录下。因为每次编译时默认都是采用增量编译，即只重新编译改变了的模块，obj保存每个模块的编译结果，用来加快编译速度。是否采用增量编译，可以通过：项目属性—>配置属性—>高级—>增量编译来设置。
+ Properties文件夹 定义你程序集的属性 项目属性文件夹 一般只有一个 AssemblyInfo.cs 类文件，用于保存程序集的信息，如名称，版本等，这些信息一般与项目属性面板中的数据对应，不需要手动编写。
+ .cs 类文件。源代码都写在这里，主要就看这里的代码。
+ .resx 资源文件，一些资源存放在这里，一般不需要看。
+ .csproj C#项目文件，用VS打开这个文件就可以直接打开这个项目，自动生成，不需要看。
+ .csproj.user 是一个配置文件，自动生成的，会记录项目生成路径、项目启动程序等信息。也不需要看。
+ .Designer.cs 设计文件，自动生成，不需要看。
+ .aspx 是网页文件，HTML代码写在这里面。
+ sln:在开发环境中使用的解决方案文件。它将一个或多个项目的所有元素组织到单个的解决方案中。此文件存储在父项目目录中.解决方案文件，他是一个或多个.proj（项目）的集合
+ *.sln：(Visual Studio.Solution) 通过为环境提供对项目、项目项和解决方案项在磁盘上位置的引用,可将它们组织到解决方案中。

比如是生成Debug模式,还是Release模式,是通用CPU还是专用的等
编译和运行直接按F5，至于调试按F9插入断电，F10整行执行，F5，F9，F10配合使用

# 大漠插件使用
http://blog.csdn.net/lsgy2008/article/details/8216484
* 1、把大漠插件 dm.dll 转成.net程序集。方法：在Visual Studio 命令提示 中输入 Tlbimp C:\dm\dm.dll /out: C:\dm\dmNet.dll 即可。
* 2、注册dm.dll。把源dm.dll注册一下。
* 3、工程dm目录里面dmNet.dll需引用；系统字库数字作为ocr数字识别用处。

# 如何打包参考
https://www.cnblogs.com/overstep/p/6942423.html

# 使用nuget管理包
https://docs.microsoft.com/zh-cn/nuget/quickstart/install-and-use-a-package-in-visual-studio

# 注册码实现
http://www.jb51.net/article/70890.htm
http://blog.csdn.net/qq870841070/article/details/76714070