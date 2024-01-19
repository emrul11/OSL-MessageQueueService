# Message Queue Service Demo

This is a demo project showcasing a message queue service implementation using RabbitMQ and .NET 4.7.

## Overview

The project demonstrates the following features:

- Two channels: Channel A and Channel B.
- Two message publishers for each channel.
- Two or more consumers for each channel.
- Two consumers shared between both channels.

## Prerequisites

- [.NET Framework 4.7](https://dotnet.microsoft.com/download/dotnet-framework/net47)
- [RabbitMQ Server](https://www.rabbitmq.com/download.html)

## Setup

1. Clone the repository:

   ```bash
   git clone https://github.com/emrul11/OSL-MessageQueueService
   ```

2. Open the solution in Visual Studio.

3. Configure RabbitMQ:

   - Install RabbitMQ. docker run --hostname rabbit --name rabbit-server -p 15672:15672 -p 5672:5672 rabbitmq:3.12.12-management
   - Update RabbitMQ connection details in the project as needed. (MessageQueueService/Infrastructure/Connections/RabbitMQConnection.cs)

4. Build and Run the Solution:

   - Build the solution in Visual Studio.
   - Run the application.

## Project Structure

- **MessageQueueService.ShowConsumedMessage**: View consumed messages.
- **MessageQueueService.Common**: Shared models and common utilities.
- **MessageQueueService.Infrastructure.Connections**: Connection setup for RabbitMQ.
- **MessageQueueService.Publisher**: Message publishers for Channel A and Channel B.
- **MessageQueueService.Consumer**: Consumers for Channel A and Channel B.
- **MessageQueueService.Web**: Web project containing controllers, views, and application setup.

## Usage

1. Open the web application in your browser.
2. Use the provided UI to publish messages to Channel A and Channel B.
3. Consumers will automatically process the messages and print them in the console.

## Additional Notes

- Make sure RabbitMQ server is running before starting the application.
- Check RabbitMQ connection details in the code and update them accordingly.
- Customize the logic in consumers based on your specific requirements.

## Contributors

- [Md. Emrul Kabir](https://github.com/emrul11)

## License

This project is open source.
