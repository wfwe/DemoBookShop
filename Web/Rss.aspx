<?xml version="1.0" ?>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rss.aspx.cs" Inherits="BookShop.Web.Rss" %>
<rss version="2.0">
<channel>
<title>XXX网站书店</title>
<description></description>
<link>http://www.bookshop.com</link>
<language>zh-cn</language>
<asp:Repeater runat="server" ID="rssRepeater">
<ItemTemplate>
 <item>
  <title><%#Eval("Title") %></title>
  <link><%#Eval("Id", "http://www.bookShop.com/BookDetail.aspx?id={0}")%></link>
  <pubDate><%#Eval("PublishDate","{0:D}") %></pubDate>
  <source>xxx网上书城</source>
  <author><%#Eval("Author") %></author>
<description>
  <![CDATA[ <%#Eval("ContentDescription")%>]]> 

</description>
  </item>
</ItemTemplate>

</asp:Repeater>
 
  </channel>
  </rss>
