# web与unity服务器通信
  - [1. 需求](#1-需求)
  - [2. 功能](#2-功能)
  - [3. mu-network 导出脚本](#3-mu-network-导出脚本)
  - [4. mu-client 布置环境](#4-mu-client-布置环境)
    - [4.1. 更新 networkjs 文件](#41-更新-networkjs-文件)
      - [4.1.1. 本地拷贝](#411-本地拷贝)
      - [4.1.2. 远程下载](#412-远程下载)
    - [4.2. 修改代码](#42-修改代码)
    - [4.3. 运行脚本](#43-运行脚本)

## 1. 需求
- 实现 `H5客户端` 连接登录 `unity服务器`
- H5客户端是 `websocket` 通讯协议，而unity服务器是 `socket` 通讯协议，两者不能直接通信。所以需要一个转发网络包的 `nodejs脚本`，实现 `websocket` 和 `socket` 之间的通信

## 2. 功能
- 消息中转作用
- `H5客户端` 与 `nodejs脚本` 用 `websocket` 连接通信
- `nodejs脚本` 与 `unity服务器` 用 `socket` 连接通信
- `nodejs脚本` 收到 `H5客户端` 包后转发给 `unity服务器`，收到 `unity服务器` 包后转发给 `H5客户端`

## 3. mu-network 导出脚本

- 工程地址：http://192.168.5.212/npm-lib/mu-network.git

- 更新最新 proto 消息，mu-client/resource/net 覆盖 mu-network/resource/net

- 输出脚本文件

~~~
# 下载环境依赖
npm install --registry=https://registry.npm.taobao.org

# 生成 Msg.ts 文件
npm run msg

# 生成 netmsg.js 文件
npm run proto

# 生成 dist/network.js 文件
npm run build
~~~

- 打包部署内网服务器：http://192.168.10.57:4873/  略。。。

## 4. mu-client 布置环境

### 4.1 更新 networkjs 文件
- 内网服务器有时候关闭且不知如何打包publish，这里直接本地拷贝

#### 4.1.1 本地拷贝

- 将别人之前已下载的 `@mu文件夹` 拷贝到 `mu-client/node_modules` 下
- 用生成最新的 `dist/network.js` 替换 `@mu文件夹` 对应路径 `dist/network.js`

#### 4.1.2 远程下载

- 修改 package.json 文件

~~~
  "devDependencies": {
    "@mu/mu-network": "^1.0.5", # 每次 network.js 更新后，这个版本应该是递增。所以是有打包publish步骤
    ...
  }
~~~

- 切镜像源

~~~
# nrm 是 npm 的镜像源管理工具，全局安装 nrm
npm install -g nrm

# 增加源 源名+源路径
nrm add mu http://192.168.10.57:4873/

# 切换源
nrm use mu

# 下载或更新最新版本 @mu
npm install
~~~

### 4.2 修改代码

- LoginData.ts 文件新增 `unity服务器` 信息

- 修改 `tools/server.js` 文件

~~~
# unity ip, unity port, web port, log
# 其中 web port 为自定义，因为 中转脚本 在本地运行
const server = new net.Web2UnityServer("192.168.11.54", 9200, 9700, false);
~~~

- 修改 `MsgControl.ts` 文件 `sendLoginWeb2Unity`函数

~~~
# ip 地址指向本机，端口与 server.js 文件的 web端口 一致即可
Mu.network.connect('127.0.0.1', 9700, false);
~~~

- 修改 `ConnectServerView.ts` 文件

~~~
# 开启 web2Unity 按钮
this.view.getChild("btn_webToUnity").visible = true;
~~~

### 4.3 运行脚本

- 运行脚本

~~~
npm run web2unity
~~~

- 运行游戏 选择 `unity服务器` 并点击 `web2Unity按钮`


