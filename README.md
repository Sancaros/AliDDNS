# AliDDNS
基于云解析API的动态DNS

# 使用阿里域名API管理域名
accessKeyId</br>
accessKeySecret</br>
上述两个参数需要从阿里云控制台获取。</br>
当购买了阿里域名或者万网域名时，控制台->域名管理可以获取。</br>

# 软件功能
程序运行后驻留系统托盘，可设定倒计时参数，定时查询WAN口和域名绑定IP是否一致，当不一致时，修改域名绑定IP，从而实现动态域名效果。</br>
可设置随系统启动，此功能需要Win系统注册表修改权限。</br>
可设置启动后自动驻留系统托盘。</br>
系统托盘图标状态刷新。</br>
可设置操作日志转储。</br>
可设置TTL参数。</br>
可设置域名查询时间。</br>
可添加多条公网IP查询网址，当自动运行时逐个查询，获取有返回值的IP。</br>
实现Ngrok网络穿透，微信开发、APP开发、无公网IP实现外网访问利器。</br>

# 程序界面
![image](images/aliddns1.png "AilDDNS")</br>
![image](images/aliddns2.png "AliDDNS")</br>
![image](images/aliddns3.png "AliDDNS")</br>
![image](images/aliddns4.png "AliDDNS")</br>
