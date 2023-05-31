# gitBook +码云构建文档
  - [1. 环境](#1-环境)
    - [1.1. NodeJs](#11-nodejs)
    - [1.2. GitBook](#12-gitbook)
  - [2. 基本使用](#2-基本使用)
    - [2.1. 初始化项目](#21-初始化项目)
    - [2.2. 构建静态网页](#22-构建静态网页)
    - [2.3. 启动项目](#23-启动项目)
    - [2.4. 查看目录](#24-查看目录)
  - [3. 码云部署托管](#3-码云部署托管)

## 1. 环境

### 1.1. NodeJs

- **nodejs 环境(略)**
~~~
# cmd
nvm list # 查看已下载的 node.js 版本列表
node -v # 查看 node.js 版本
npm -v # 查看 npm 版本
~~~

### 1.2. GitBook
- **gitbook 命令行工具安装**
~~~
# cmd
npm install -g gitbook-cli
~~~

- **查看 gitbook 版本**
~~~
# cmd
gitbook -V  # 注意 -V 为大写
# 结果
CLI version: 2.3.2
GitBook version: 3.2.3  # 若出现 Installing GitBook 3.2.3 ... 且长时间无提示与结果 是因为 npm 默认国外镜像速度较慢 可考虑换源重安装
~~~

- **npm 换源重安装**
~~~
# cmd
npm config set registry=http://registry.npm.taobao.org -g
gitbook -V
~~~

## 2. 基本使用

### 2.1. 初始化项目

 - **创建项目文件夹** -> **执行命令** -> **会在当前目录自动创建 `README.md` 和 `SUMMARY.md` 两个文件**
 - **`SUMMARY.md` 是章节目录**
~~~
# cmd || git
gitbook init
~~~

### 2.2. 构建静态网页

- **`gitbook build` 命令构建 `静态网页` 而不启动本地服务器，默认生成文件存放在 `_book/` 目录**
- **`静态网页` 主要用于 `发布准备阶段`，可打包上传服务器也可以上传 `GitHub` 等网站托管**

- ![图解](../img/init_1.png)

### 2.3. 启动项目

- **`gitbook serve` 命令启动 `本地服务`，默认访问 `http://localhost:4000` 实时预览**
- **`本地服务` 主要用于 `开发调试阶段`，能够实时预览电子书效果，且大多数开发环境搭建在本地而不是远程服务器中**
- **本质是把 `_book/` 映射到网站的根目录**

- ![图解](../img/init_2.png)

### 2.4. 查看目录

- **`tree` 命令**

- ![图解](../img/init_3.png)

## 3. 码云部署托管

### 3.1. 为什么用码云部署托管

- **优点**
- **缺点**

### 3.2. 部署