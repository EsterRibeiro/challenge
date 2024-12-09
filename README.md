# Challenge Blip

Esse projeto é uma API integrada com a API do github, o objetivo do endpoint principal (GET) é carregar os últimos 5 repositórios de qualquer repositório do GitHub que tenham sido desenvolvidos em C#.

### 📋 Pré-requisitos

Para acessar a API do GitHub é necessário gerar um token na própria plataforma e configurar a variável de ambiente no visual studio. Esse token também configurável em qualquer serviço de nuvem que a API tenha sido implantada.

### 🔧 Chave no GitHub
  1. Vá no seu perfil

  2. Clique em Configurações

  3. Clique em Configurações do desenvolvedor

  4. Em Personal access tokens, clique em Tokens refinados

  5. Gerar novo token

### 🔧 Configuração de variável de ambiente no VStudio

  1. Vá no projeto Lora.Take.API
     
  2. Propriedades do projeto
     
  3. Depurar/Debug
     
  4. Geral
     
  5. Variáveis de ambiente
      
  6. Adicionar a chave e o valor

## 🛠️ Construído com

* .NET 8.0
* C# 12.0

### Pacotes
* NewtonSoft.Json
* Microsoft.Extensions.Http
* System.Net.Http


