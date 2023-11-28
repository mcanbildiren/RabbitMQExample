using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory();

using var connection = factory.CreateConnection();

var channel = connection.CreateModel();

channel.QueueDeclare("new-queue", true, false, false);

string message = "Hello World!";

var messageBody = Encoding.UTF8.GetBytes(message);

channel.BasicPublish(string.Empty, "new-queue", null, messageBody);

Console.WriteLine("Message sent!");
Console.ReadLine();