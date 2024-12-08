# <p align="center"> AIMRPC <img src="https://i.ibb.co/zrPwxfD/image-1.png" width="30" height="30"> </p>
<p align= "center">
  <img src="https://img.shields.io/github/last-commit/kingofnetflix/AIMRPC">
  <img src="https://img.shields.io/github/license/kingofnetflix/AIMRPC">
  <br>
  <img src="https://img.shields.io/github/downloads/kingofnetflix/AIMRPC/total.svg">
  <br>
  <img src="https://img.shields.io/github/stars/kingofnetflix/AIMRPC">
  <img src="https://img.shields.io/github/forks/kingofnetflix/AIMRPC">
</p>

---

### <p align="center">About</p>
<p align="center">
AIMRPC is a C# Console app offering the ability to showcase your AIM status (viewing your buddy list, texting a buddy, etc) to Discord using their Rich Presence system. Credits to <a href="https://github.com/Lachee/discord-rpc-csharp">Lachee's C# Discord RPC library</a>
</p>

---

### <p align="center">Setup</p>
<p align="center">
First, you need AOL Instant Messenger. You can find that <a href="http://www.oldversion.com/windows/aol-instant-messenger-5-0-2829">here</a> or <a href="https://cdn.discordapp.com/attachments/1308165030541267044/1315165780748402719/aim48.exe?">here if you can not install the first one</a> 
Go to the <a href="https://github.com/kingofnetflix/AIMRPC/releases/latest">latest release</a> and download the zip. Once downloaded, unextract it. Then open it. Easy! 🎉
</p>

---

### <p align="center">Editing Config</p>
<p align="center">
In the zip file you unextracted, there should be a config.json. Go ahead and open it. You should see a file that looks like this:
</p>

```
{
  "application_id": "1214816314170941511",
  "debug_level": "MESSAGE"
}
```
<p align="center">
This is the default config file. Feel free to use it! It will automatically set you up on the easy way to use AIMRPC. If you would like to know all the debug levels though, here they are:
</p>

```
INFO,
WARN,
ERROR,
FATAL,
MESSAGE
```
<p align="center">
If you would like to know how to use your own client ID, look below to the Custom Application ID section.
</p>

---

### <p align="center">Custom Application ID</p>
<p align="center">
First, you want to setup a Discord account if you have not already. Then, go to the <a href="https://discord.com/developers/applications">Discord Developer Portal</a> and create a new application. Please note that the name of this application will be the name of the RPC name, so I recommend setting it to "AOL Instant Messenger" or something similar.
<p align="center">
  <img src="https://i.ibb.co/DD21jH7/image.png">
</p>
<p align="center">
Once you have created your application, go ahead and scroll down until you see the application ID.
</p>
<p align="center">
  <img src="https://i.ibb.co/C074NM4/image.png">
</p>
After copying the application ID, go to where you downloaded AIMRPC, and make/edit the file config.json. Paste your application ID where it says `application_id`. It should look somewhat like this:
</p>

```
{
  "application_id": "(your application id here)",
  "debug_level": "MESSAGE"
}
```
<p align="center">
After that, you are done! Have fun :D
</p>


---
