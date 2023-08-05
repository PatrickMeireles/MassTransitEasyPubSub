# MassTransitEasyPubSub

- It's easy project using Masstransit and RabbitMq

## Usage

- Execute `docker compose up` to execute the RabbitMq
- Run the solution
    - Send a POST `{URL}/person` that will send a message to RabbitMq Queue (person_create) and there is a Consumer who will consume this message and add a log.