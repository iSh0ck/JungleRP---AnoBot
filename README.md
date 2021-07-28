# About
This is a discord bot for RP server. He can manage your anonym chat, twitter and instagram channels.

# Functionnalities
- The bot can do:
  - Replace message from user by a builder for anonym chat
  - Replace message from user by a builder for twitter chat
  - Replace message from user by a builder for instagram chat
  - For the anonym chat the bot will log all message with the user who send the message (admin) 

# Prerequires
- First of all you will need to get .Net Core 5.0
- In second time you will need to update credential into the code in these two files:
  - Discord.cs
  - Program.cs
- In Discord.cs you will need to update the differents ID of channels & server
- In Program.cs you will need to update the differents ID of group permission to get notified
- You can search (CTRL+F) for "SearchMe_" and you can edit credentials at these places

### Dotnet & Linux
I'm using this bot on Linux so i will explain you how you can install .NET on Linux (Debian 10)

1. Add Microsoft package
```BASH
wget https://packages.microsoft.com/config/debian/10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
```
2. Install the SDK
```BASH
sudo apt-get update; \
  sudo apt-get install -y apt-transport-https && \
  sudo apt-get update && \
  sudo apt-get install -y dotnet-sdk-5.0
```
3. Install the runtime
```BASH
sudo apt-get update; \
  sudo apt-get install -y apt-transport-https && \
  sudo apt-get update && \
  sudo apt-get install -y aspnetcore-runtime-5.0
```
> All information about the installation of .NET on Linux can be found here: https://docs.microsoft.com/en-us/dotnet/core/install/linux-debian

# Screenshots
![Image of twitter](https://user-images.githubusercontent.com/30291488/127342189-f82f2388-abb4-432f-82dd-863818f1acfd.png)
![Image of instagram](https://user-images.githubusercontent.com/30291488/127342389-5344ab78-4f58-4c9f-83cb-8158e17719d7.png)
![Image of anonym chat](https://i.imgur.com/31XsaMz.png)
