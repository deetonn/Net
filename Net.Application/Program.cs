﻿using Net;
using Net.Config;
using Net.Core.Logging;
using Net.Core.Messages;
using Net.Core.Server.Connection.Identity;

using Net.Services.DirectoryLayoutBuilder;


new DirectoryLayout(Path.Join(Directory.GetCurrentDirectory(), "net"))
    .MakeTopLevel("config")
        .MakeDotFile("config")
        .ToRoot()
    .MakeTopLevel("saved")
        .MakeNew("users")
            .GoBack()
        .ToRoot();

/*
 * creates a local server + client
 */

ConfigurationManager.UseLogger<DebugLogger>();

Factory.SetGlobalConnectionDetails("localhost", 56433);

var identity = new DefaultId("Deeton");

var server = await Factory.MakeServerFromDetails<DefaultId>();
var client = await Factory.MakeClientFromDetails<NetMessage<DefaultId>, DefaultId>(identity);

client.On("connected", (args) =>
{
    Console.WriteLine("connected to the server!");
});

client.On("display", (message) =>
{
    if (!message.Properties.ContainsKey("text"))
    {
        return;
    }


});

var msg = 
    await 
    Factory.MessageFromResourceString<NetMessage<DefaultId>, DefaultId>("display?text='Willy And Balls'");

if (msg is null)
{
    return;
}

await server.RhetoricalSendTo
    (IdentityType.Name, "Deeton",
    msg);

Console.ReadLine();