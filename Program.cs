using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace JungleRP___AnoBot
{
    class Program
    {
        // Nom du bot
        private String botName = "SearchMe_ChangeBotName#9999";

        // Déclaration des channels
        private ulong channelDarkChatID = 000000000000000000; // SearchMe_ChangeDarkchatChannelID
        private ulong channelTwitterID = 000000000000000000; // SearchMe_ChangeTwitterChannelID
        private ulong channelInstaID = 000000000000000000; // SearchMe_ChangeInstagramChannelID
        private ulong channelLogID = 000000000000000000; // SearchMe_ChangeLogChannelID (For admin)

        // ID du serveur
        private ulong serverID = 000000000000000000; // SearchMe_ChangeServerID

        // Initialisation du client discord
        private DiscordSocketClient client;

        static void Main(string[] args) => new Program().RunBotAsync().GetAwaiter().GetResult();

        public async Task RunBotAsync()
        {
            client = new DiscordSocketClient();

            client.Log += Log;

            client.Ready += () =>
            {
                Console.WriteLine("Bot is ready");
                return Task.CompletedTask;
            };

            // Connexion du bot avec le token
            await client.LoginAsync(TokenType.Bot, "SearchMe_ChangeWithYourDiscordBotToken");
            await client.StartAsync();

            client.MessageReceived += onMessage;

            await Task.Delay(-1);
        }

        private async Task onMessage(SocketMessage pMsg)
        {
            if (pMsg.Channel.Id == channelDarkChatID && pMsg.Author.ToString() != botName)
            {
                await darkChatEvent(pMsg);
                await logEvent(pMsg);
            }

            if (pMsg.Channel.Id == channelTwitterID && pMsg.Author.ToString() != botName)
            {
                await twitterChatEvent(pMsg);
            }

            if (pMsg.Channel.Id == channelInstaID && pMsg.Author.ToString() != botName)
            {
                await instaChatEvent(pMsg);
            }
        }

        private async Task darkChatEvent(SocketMessage pMsg)
        {
            var prefix = '[' + pMsg.Timestamp.ToString() + ']';
            Console.WriteLine(prefix + " Message: " + pMsg + ' ' + "Auteur: " + pMsg.Author + ' ' + "ID: " + pMsg.Author.Id);
            var msg = (SocketUserMessage)pMsg;
            var context = new SocketCommandContext(client, msg);

            if (pMsg.Attachments.Count > 0)
            {
                var attachments = context.Message.Attachments.Where(x =>
                    x.Filename.EndsWith(".jpg") || x.Filename.EndsWith(".png") || x.Filename.EndsWith(".gif"));

                if (attachments.Any())
                {
                    EmbedBuilder builder = new EmbedBuilder();
                    builder.WithColor(Color.DarkRed);
                    builder.WithDescription(pMsg.ToString());
                    builder.WithImageUrl(context.Message.Attachments.FirstOrDefault().Url);
                    builder.WithTimestamp(pMsg.Timestamp);
                    builder.WithFooter("Message chiffré");

                    await context.Channel.DeleteMessageAsync(pMsg.Id);
                    await context.Channel.SendMessageAsync("", false, builder.Build());
                }
                else
                {
                    EmbedBuilder builder = new EmbedBuilder();
                    builder.WithColor(Color.DarkRed);
                    builder.WithDescription(pMsg.ToString());
                    builder.WithTimestamp(pMsg.Timestamp);
                    builder.WithFooter("Message chiffré");

                    await context.Channel.DeleteMessageAsync(pMsg.Id);
                    await context.Channel.SendMessageAsync("", false, builder.Build());
                }


            }
            else
            {
                EmbedBuilder builder = new EmbedBuilder();
                builder.WithColor(Color.DarkRed);
                builder.WithDescription(pMsg.ToString());
                builder.WithTimestamp(pMsg.Timestamp);
                builder.WithFooter("Message chiffré");

                await context.Channel.DeleteMessageAsync(pMsg.Id);
                await context.Channel.SendMessageAsync("", false, builder.Build());
            }

        }

        private async Task twitterChatEvent(SocketMessage pMsg)
        {
            var prefix = '[' + pMsg.Timestamp.ToString() + ']';
            Console.WriteLine(prefix + " Message: " + pMsg + ' ' + "Auteur: " + pMsg.Author + ' ' + "ID: " + pMsg.Author.Id);
            var msg = (SocketUserMessage)pMsg;
            var context = new SocketCommandContext(client, msg);

            if (pMsg.Attachments.Count > 0)
            {
                var attachments = context.Message.Attachments.Where(x =>
                    x.Filename.EndsWith(".jpg") || x.Filename.EndsWith(".png") || x.Filename.EndsWith(".gif"));

                if (attachments.Any())
                {
                    EmbedBuilder builder = new EmbedBuilder();
                    builder.WithColor(Color.Blue);
                    builder.WithAuthor(pMsg.Author);
                    builder.WithDescription(pMsg.ToString());
                    builder.WithImageUrl(context.Message.Attachments.FirstOrDefault().Url);
                    builder.WithTimestamp(pMsg.Timestamp);
                    builder.WithFooter("Twitter");

                    await context.Channel.DeleteMessageAsync(pMsg.Id);
                    await context.Channel.SendMessageAsync("", false, builder.Build());
                }
                else
                {
                    EmbedBuilder builder = new EmbedBuilder();
                    builder.WithColor(Color.Blue);
                    builder.WithAuthor(pMsg.Author);
                    builder.WithDescription(pMsg.ToString());
                    builder.WithTimestamp(pMsg.Timestamp);
                    builder.WithFooter("Twitter");

                    await context.Channel.DeleteMessageAsync(pMsg.Id);
                    await context.Channel.SendMessageAsync("", false, builder.Build());
                }
            }
            else
            {
                EmbedBuilder builder = new EmbedBuilder();
                builder.WithColor(Color.Blue);
                builder.WithAuthor(pMsg.Author);
                builder.WithDescription(pMsg.ToString());
                builder.WithTimestamp(pMsg.Timestamp);
                builder.WithFooter("Twitter");

                await context.Channel.DeleteMessageAsync(pMsg.Id);
                await context.Channel.SendMessageAsync("", false, builder.Build());
            }

        }

        private async Task instaChatEvent(SocketMessage pMsg)
        {
            var prefix = '[' + pMsg.Timestamp.ToString() + ']';
            Console.WriteLine(prefix + " Message: " + pMsg + ' ' + "Auteur: " + pMsg.Author + ' ' + "ID: " + pMsg.Author.Id);
            var msg = (SocketUserMessage)pMsg;
            var context = new SocketCommandContext(client, msg);

            if (pMsg.Attachments.Count > 0)
            {
                var attachments = context.Message.Attachments.Where(x =>
                    x.Filename.EndsWith(".jpg") || x.Filename.EndsWith(".png") || x.Filename.EndsWith(".gif"));

                if (attachments.Any())
                {
                    EmbedBuilder builder = new EmbedBuilder();
                    builder.WithColor(Color.Purple);
                    builder.WithAuthor(pMsg.Author);
                    builder.WithDescription(pMsg.ToString());
                    builder.WithImageUrl(context.Message.Attachments.FirstOrDefault().Url);
                    builder.WithTimestamp(pMsg.Timestamp);
                    builder.WithFooter("Instagram");

                    await context.Channel.DeleteMessageAsync(pMsg.Id);
                    await context.Channel.SendMessageAsync("", false, builder.Build());
                }
                else
                {
                    EmbedBuilder builder = new EmbedBuilder();
                    builder.WithColor(Color.Purple);
                    builder.WithAuthor(pMsg.Author);
                    builder.WithDescription(pMsg.ToString());
                    builder.WithTimestamp(pMsg.Timestamp);
                    builder.WithFooter("Instagram");

                    await context.Channel.DeleteMessageAsync(pMsg.Id);
                    await context.Channel.SendMessageAsync("", false, builder.Build());
                }
            }
            else
            {
                EmbedBuilder builder = new EmbedBuilder();
                builder.WithColor(Color.Purple);
                builder.WithAuthor(pMsg.Author);
                builder.WithDescription(pMsg.ToString());
                builder.WithTimestamp(pMsg.Timestamp);
                builder.WithFooter("Instagram");

                await context.Channel.DeleteMessageAsync(pMsg.Id);
                await context.Channel.SendMessageAsync("", false, builder.Build());
            }

        }

        private async Task logEvent(SocketMessage pMsg)
        {
            var msg = (SocketUserMessage)pMsg;
            var context = new SocketCommandContext(client, msg);

            if (pMsg.Attachments.Count > 0)
            {
                var attachments = context.Message.Attachments.Where(x =>
                    x.Filename.EndsWith(".jpg") || x.Filename.EndsWith(".png") || x.Filename.EndsWith(".gif"));

                if (attachments.Any())
                {
                    EmbedBuilder builderLog = new EmbedBuilder();
                    builderLog.WithColor(Color.DarkRed);
                    builderLog.WithAuthor(pMsg.Author);
                    builderLog.WithDescription(pMsg.ToString());
                    builderLog.WithImageUrl(context.Message.Attachments.FirstOrDefault().Url);
                    builderLog.WithTimestamp(pMsg.Timestamp);
                    builderLog.WithFooter("Message chiffré par: " + pMsg.Author + " (" + pMsg.Author.Id + ')');

                    await client.GetGuild(serverID).GetTextChannel(channelLogID).SendMessageAsync("", false, builderLog.Build());
                }
                else
                {
                    EmbedBuilder builderLog = new EmbedBuilder();
                    builderLog.WithColor(Color.DarkRed);
                    builderLog.WithAuthor(pMsg.Author);
                    builderLog.WithDescription(pMsg.ToString());
                    builderLog.WithTimestamp(pMsg.Timestamp);
                    builderLog.WithFooter("Message chiffré par: " + pMsg.Author + " (" + pMsg.Author.Id + ')');

                    await client.GetGuild(serverID).GetTextChannel(channelLogID).SendMessageAsync("", false, builderLog.Build());
                }
            }
            else
            {
                EmbedBuilder builder = new EmbedBuilder();
                builder.WithColor(Color.DarkRed);
                builder.WithAuthor(pMsg.Author);
                builder.WithDescription(pMsg.ToString());
                builder.WithTimestamp(pMsg.Timestamp);
                builder.WithFooter("Message chiffré par: " + pMsg.Author + " (" + pMsg.Author.Id + ')');

                await client.GetGuild(serverID).GetTextChannel(channelLogID).SendMessageAsync("", false, builder.Build());
            }
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
