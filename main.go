package main

import (
	"bytes"
	"fmt"
	"log"
	"net/http"
	"os"

	"github.com/olakara/handoff/component"
)

const indexHTMLTemplate = `<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<title>Handoff</title>
</head>
<body>
	%s
	<p style="color: purple;">Welcome to Go handoff!</p>
</body>
</html>
`

func indexHandler(w http.ResponseWriter, r *http.Request) {
	name := r.URL.Query().Get("name")
	if name == "" {
		name = "World"
	}

	var hello bytes.Buffer
	if err := component.Hello(name).Render(r.Context(), &hello); err != nil {
		http.Error(w, err.Error(), http.StatusInternalServerError)
		return
	}

	w.Header().Set("Content-Type", "text/html; charset=utf-8")
	fmt.Fprintf(w, indexHTMLTemplate, hello.String())
}

func main() {
	port := os.Getenv("PORT")
	if port == "" {
		port = "8080"
	}

	http.HandleFunc("/", indexHandler)

	addr := ":" + port
	log.Printf("listening on %s", addr)
	if err := http.ListenAndServe(addr, nil); err != nil {
		log.Fatal(err)
	}
}
