# grupo04-projeto
# 🃏 Fate/Concordia (Nome Provisório)

> Um card game baseado em *Yu-Gi-Oh!* e na franquia *Fate*, com modos de progressão PVE, multijogador local e multijogador online.

---

## 🧩 Sumário

1. [Descrição Geral](#descrição-geral)
2. [Funcionalidades](#funcionalidades)
3. [Requisitos do Sistema](#requisitos-do-sistema)
4. [Tecnologias Utilizadas](#tecnologias-utilizadas)
5. [Banco de Dados](#banco-de-dados)

---

## 🧠 Descrição Geral

**Fate/Concordia** é um projeto de jogo de cartas desenvolvido em **C# (Windows Forms)** que combina os conceitos estratégicos de *Yu-Gi-Oh!* com o universo e personagens da franquia *Fate*.

O jogo permite partidas **locais** e **online**, além de um **modo PVE** onde o jogador enfrenta oponentes controlados por IA.  
Com interface personalizada e integração com banco de dados remoto, o objetivo é criar uma experiência visualmente rica e tecnicamente sólida.

---

## ⚔️ Funcionalidades

- 🧍‍♂️ **Modo PVE** – Batalhas contra oponentes de IA com dificuldade progressiva.  
- 👥 **Modo Local (VS)** – Jogo entre dois jogadores no mesmo dispositivo.  
- 🌐 **Modo Online** – Sistema de conexão via servidor remoto (HostGator).  
- 🧾 **Sistema de Decks** – Criação e personalização de decks.  
- 🎴 **Banco de Dados Remoto** – Armazena cartas, jogadores e estatísticas.  
- 💾 **Login e Progressão** – Sistema de autenticação e armazenamento de dados.  
- ⚙️ **Interface Adaptável** – Layouts otimizados para diferentes resoluções.

---

## 🖥️ Requisitos do Sistema

| Requisito | Versão mínima |
|------------|----------------|
| **Sistema Operacional** | Windows 10 ou superior |
| **.NET Runtime** | .NET 8.0 (ou compatível) |
| **Memória RAM** | 4 GB |
| **Armazenamento** | 200 MB |
| **Conexão Internet** | Necessária para modo online |

---

## 💡 Tecnologias Utilizadas

- 🧰 **Linguagem:** C#  
- 🪟 **Interface:** Windows Forms  
- 🧱 **IDE:** Visual Studio 2022  
- 🗄️ **Banco de Dados:** MySQL remoto (HostGator)  
- ⚙️ **Versionamento:** Git / GitHub

---

## 🗄️ Banco de Dados

O projeto utiliza um banco de dados MySQL remoto, hospedado no HostGator, que armazena:

- Informações de jogadores
- Cartas disponiveis
- Decks e associações
- Dados de login

## 📁 Estrutura básica (exemplo):

| Tabela        | Campos principais                        |
| ------------- | ---------------------------------------- |
| `jogador`     | id_jogador, nome, senha                  |
| `carta`       | id_carta, nome, atk, def, frete, classe, efeito, limite, raridade |
| `deck`        | nome_deck, id_carta, id_jogador, quantidade           |

## 👨‍💻 Autores e Créditos

Desenvolvido por:
🎨 Thiago Leandro de Lira
📧 lirathiago63@gmail.com

Orientador / Professor:
👨‍🏫 João Lagoas e Flavio Costa

Instituição:
🏫 Colégio Pedro II - Campus São Cristóvão III
🗓️ Ano: 2025
📗 Turma: DS311 / 3º ano – Desenvolvimento de Sistemas