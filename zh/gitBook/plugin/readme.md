# 插件
  - [1. 安装](#1-安装)
    - [1.1. book 文件配置](#11-book-文件配置)
    - [1.2. 下载安装](#12-下载安装)
    - [1.3. 生效](#13-生效)
    - [1.4. 失败案例](#14-失败案例)
  - [2. 常用插件](#2-常用插件)
    - [2.1. 侧边栏目录导航](#21-侧边栏目录导航)

## 1. 安装

### 1.1. book 文件配置

- **book.json 文件配置 plugins字段**
~~~
{
    "plugins": [
        "expandable-chapters-small@git+https://gitee.com/mirrors_cocos-creator/gitbook-plugin-expandable-chapters-small.git"
    ]
}
# ${插件名}@git+${重定向地址}
# 步骤顺序无要求、最后一步配置也行（若使用 gitbook install 安装需先执行此步骤）
~~~

### 1.2. 下载安装

- **方式一：npm install**
~~~
# cmd
npm init -y # 若无 package.json 执行此命令、其中 -y 表示直接生成默认文件
npm install gitbook-plugin-${插件名}    # 下载安装插件
npm install gitbook-plugin-${插件名}@git+${重定向地址}  # 下载安装插件、若默认下载不行则重定向下载地址
~~~

- 

- **方式二：gitbook install**
~~~
# cmd
gitbook install # 可能不太好用
~~~

- **方式三：直接下载源码，放到 node_modules 文件夹里**

### 1.3. 生效

- **重启服务或者重新打包构建可看到效果**
~~~
# cmd
gitbook serve # 重启服务
~~~

### 1.4. 失败案例
- **案例一**
  - ![图解](./img/1.png)
  ~~~
  # 使用 vpn 或者 代理服务器时，可能会导致网络请求失败
  # 此报错之前有设置过 淘宝源 npm config set registry https://registry.npm.taobao.org 所以这里去掉试试
  # 地址：C:\Users\admin下 .npmrc 文件打开 去掉 registry=http://192.168.10.57:4873/ 这行保存
  # 重新执行 npm install gitbook-plugin-splitter 成功
  ~~~

## 2. 常用插件

### 2.1. 侧边栏目录导航
- **gitbook 默认左侧为目录索引导航、且默认目录是全部展开的**

### 2.1.1. chapter-fold
- **略**

### 2.1.2. expandable-chapters
- **略**

### 2.1.3. expandable-chapters-small
- **可使目录默认折叠且展开后不会自动折叠，箭头相比 expandable-chapters 会细一些**
~~~
{
    "plugins": [
        "expandable-chapters-small@git+https://gitee.com/mirrors_cocos-creator/gitbook-plugin-expandable-chapters-small.git"
    ]
}
# 地址重定向：默认地址下载不到、这里重定向到国内地址
# bug：该重定向地址的插件有问题、只能同时展开一个子目录。
# bug优化：laya文档也使用该插件且没有bug、对比了下代码有优化。后面该插件迁移自己的地址参照优化后再重定向新地址重新拉取
~~~

### 2.1.4. splitter
- **侧边栏宽度调节**
~~~
{
    "plugins": [
        "splitter"
    ]
}
~~~