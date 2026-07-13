# Handoff

Handoff is a learning project for exploring **agent handoff workflows**: how
coding agents (like Claude and GitHub Copilot) can pick up, continue, and pass
along work on a codebase, and how the Herdr terminal multiplexer can be used
to orchestrate and observe multiple coding agents working together.

## Status

A minimal Go web application has been scaffolded: it serves a "Hello World"
page on port 8080.

## Running the app

```bash
go run .
```

The server listens on port 8080 by default (override with the `PORT`
environment variable), and serves a page with an `<h1>Hello World</h1>`
heading and a purple "Welcome to Go handoff!" message.

## Testing

```bash
go test ./...
```
