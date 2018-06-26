using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Internals;
using Microsoft.Bot.Connector;
using Welo.Application.Interfaces;
using Welo.Bot.Commands.Interfaces;
using Welo.Domain.Entities;

namespace Welo.Bot.Commands
{
    [Serializable]
    public class FilmeCommand : IFilmeCommand
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> obj)
        {
            var message = await obj;

            using (var scope = DialogModule.BeginLifetimeScope(Conversation.Container, message))
            {
                var _service = scope.Resolve<IFilmeAppService>();
                IMessageActivity activity = context.MakeMessage();
                var response = _service.GetAll();
                var card = CreateCardMessage(response);
                activity.Attachments.Add(card?.ToAttachment());

                context.Done(activity);
            }
        }

        private static HeroCard CreateCardMessage(IEnumerable<FilmeEntity> response)
        {
            if (response == null)
                return null;

            var cardButtons = response.Select(f => new CardAction()
            {
                Value = f.Id.ToString(),
                Type = string.Join(",", f.Genero.ToArray()),
                Title = f.Nome
            }).ToList();

            return new HeroCard
            {
                Title = "Lista de Filmes",
                Subtitle = "MyBot",
                Text = "Escolha qual filme vc quer.",
                Buttons = cardButtons
            };

        }
    }
}