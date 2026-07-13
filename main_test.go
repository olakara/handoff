package main

import (
	"net/http"
	"net/http/httptest"
	"strings"
	"testing"
)

func TestIndexHandler(t *testing.T) {
	req := httptest.NewRequest(http.MethodGet, "/", nil)
	rec := httptest.NewRecorder()

	indexHandler(rec, req)

	if rec.Code != http.StatusOK {
		t.Fatalf("expected status %d, got %d", http.StatusOK, rec.Code)
	}

	body := rec.Body.String()

	if !strings.Contains(body, "<h1>Hello World</h1>") {
		t.Errorf("expected body to contain H1 Hello World, got: %s", body)
	}

	if !strings.Contains(body, `style="color: purple;"`) || !strings.Contains(body, "Welcome to Go handoff!") {
		t.Errorf("expected body to contain purple welcome message, got: %s", body)
	}
}
