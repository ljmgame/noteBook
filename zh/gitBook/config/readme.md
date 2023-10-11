# 配置

- 文件：**book.json**

## 1. title
- **设置书本的标题**
~~~
{
    "title": "笔记"
}
~~~

## 2. author
- **作者的相关信息**
~~~
{
    "author": "ljmyx"
}
~~~

## 3. desctiption
- **书本的简单描述**
~~~
{
    "desctiption": "技术文档"
}
~~~

## 4. language
- **使用的语言**
~~~
{
    "language": "zh-hans"   // 简体中文、但好像没用
}
~~~

## 5. links
- **添加链接信息**
~~~
{
    "links": {
        "sidebar": {
            "Home": "https://www.baidu.com" // 左侧导航栏添加链接信息
        }
    }
}
~~~

## 6. styles
- **自定义页面样式**
- 一：编辑 **book.json** 文件，添加下方内容。不同格式对应不同 **css** 文件
~~~
{
    "styles": {
        "website": "styles/website.css",    // 默认的静态网站格式、主要由 HTML、Javascript、CSS 组成
        "ebook": "styles/ebook.css",
        "pdf": "styles/pdf.css",    // pdf格式、文件拓展名 .pdf
        "mobi": "styles/mobi.css",
        "epub": "styles/epub.css"
    },
}
~~~
- 二：**book 根目录（这里 zh/ 文件夹）下创建 styles 文件夹，并在其中创建 对应的 css 文件（例如：website.css）**

### 6.1. 移除 “本书使用GitBook发布” 字样
- **修改 website.css 文件**
~~~
.gitbook-link {
    display: none !important;
}
~~~

## 7. plugins
- **插件列表**

### 7.1 添加插件
~~~
{
    "plugins": [
        "search-pro",
        "splitter",
        "anchor-navigation-ex"
    ],
}
~~~

### 7.2 去除插件
~~~
{
    "plugins": [
        "-lunr",
        "-search",
        "-sharing"
    ],
}
~~~

## 8. pluginsConfig
- **插件属性配置**