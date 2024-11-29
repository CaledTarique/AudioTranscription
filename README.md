# Whisper.net Audio Transcription

Este projeto em C# utiliza a biblioteca [Whisper.net](https://github.com/sandrohanea/whisper.net) para transcrever arquivos de áudio em texto, com suporte ao modelo **Whisper LargeV3** da OpenAI.

## Funcionalidades

- Converte arquivos `.mp3` para `.wav` usando **FFmpeg**.
- Transcreve o áudio para texto.
- Salva a transcrição no arquivo `transcricao.txt`.

## Requisitos

- .NET 6.0 ou superior.
- **FFmpeg** instalado e configurado no PATH.
- Conexão com a Internet para baixar o modelo Whisper, se necessário.

## Como Usar

1. Certifique-se de ter o **FFmpeg** instalado.
2. Compile e execute o projeto:
   ```bash
   dotnet run
   ```
3. Certifique-se de que o arquivo de áudio com ou vídeo esteja no diretório raiz.

A transcrição será exibida no console e salva em `transcricao.txt`.

## Personalização

- Altere o idioma da transcrição no código:  
  ```csharp
  .WithLanguage("portuguese")
  ```

- Use outros modelos alterando a configuração `GgmlType`.

## Licença

Este projeto é licenciado sob a [MIT License](LICENSE).
