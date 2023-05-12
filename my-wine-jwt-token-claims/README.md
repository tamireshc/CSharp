# Boas-vindas ao repositório do exercício `My Wine` 🍷

Para realizar o projeto, atente-se a cada passo descrito a seguir. Se tiver qualquer dúvida, nos envie por _Slack_! #vqv 🚀

Aqui você vai encontrar os detalhes de como estruturar o desenvolvimento do seu projeto a partir deste repositório, utilizando uma branch específica e um _Pull Request_ para colocar seus códigos.

# Termos e acordos

Ao iniciar este projeto, você concorda com as diretrizes do Código de Conduta e do Manual da Pessoa Estudante da Trybe.

# Orientações

<details>
  <summary><strong>‼️ Antes de começar a desenvolver</strong></summary><br />

  1. Clone o repositório

  - Use o comando: `git clone git@github.com:tryber/acc-csharp-0x-project/exercises-my-wine.git`.
  - Entre na pasta do repositório que você acabou de clonar:
    - `cd acc-csharp-0x-project/exercises-my-wine`

  2. Instale as dependências
  
  - Entre na pasta `src/`.
  - Execute o comando: `dotnet restore`.
  
  3. Crie uma branch a partir da branch `master`

  - Verifique se você está na branch `master`
    - Exemplo: `git branch`
  - Se não estiver, mude para a branch `master`
    - Exemplo: `git checkout master`
  - Agora crie uma branch à qual você vai submeter os `commits` do seu projeto
    - Você deve criar uma branch no seguinte formato: `nome-de-usuario-nome-do-projeto`
    - Exemplo: `git checkout -b joaozinho-acc-0x-project/exercises-my-wine`

  4. Adicione as mudanças ao _stage_ do Git e faça um `commit`

  - Verifique que as mudanças ainda não estão no _stage_
    - Exemplo: `git status` (deve aparecer listada a pasta _joaozinho_ em vermelho)
  - Adicione o novo arquivo ao _stage_ do Git
    - Exemplo:
      - `git add .` (adicionando todas as mudanças - _que estavam em vermelho_ - ao stage do Git)
      - `git status` (deve aparecer listado o arquivo _joaozinho/README.md_ em verde)
  - Faça o `commit` inicial
    - Exemplo:
      - `git commit -m 'iniciando o projeto x'` (fazendo o primeiro commit)
      - `git status` (deve aparecer uma mensagem tipo essa: _nothing to commit_ )

  5. Adicione a sua branch com o novo `commit` ao repositório remoto

  - Usando o exemplo anterior: `git push -u origin joaozinho-acc-0x-project/exercises-my-wine`

  6. Crie um novo `Pull Request` _(PR)_

  - Vá até a página de _Pull Requests_ do [repositório no GitHub](https://github.com/tryber/acc-csharp-0x-project/exercises-my-wine/pulls)
  - Clique no botão verde _"New pull request"_
  - Clique na caixa de seleção _"Compare"_ e escolha a sua branch **com atenção**
  - Coloque um título para a sua _Pull Request_
    - Exemplo: _"Cria tela de busca"_
  - Clique no botão verde _"Create pull request"_
  - Adicione uma descrição para o _Pull Request_ e clique no botão verde _"Create pull request"_
  - **Não se preocupe em preencher mais nada por enquanto!**
  - Volte até a [página de _Pull Requests_ do repositório](https://github.com/tryber/acc-csharp-0x-project/exercises-my-wine/pulls) e confira que o seu _Pull Request_ está criado

</details>

<details>
  <summary><strong>⌨️ Durante o desenvolvimento</strong></summary><br/>

  - Faça `commits` das alterações que você fizer no código regularmente

  - Lembre-se sempre de, após um (ou alguns) `commits`, atualizar o repositório remoto

  - Os comandos que você utilizará com mais frequência são:
    1. `git status` _(para verificar o que está em vermelho - fora do stage - e o que está em verde - no stage)_
    2. `git add` _(para adicionar arquivos ao stage do Git)_
    3. `git commit` _(para criar um commit com os arquivos que estão no stage do Git)_
    4. `git push -u origin nome-da-branch` _(para enviar o commit para o repositório remoto na primeira vez que fizer o `push` de uma nova branch)_
    5. `git push` _(para enviar o commit para o repositório remoto após o passo anterior)_

</details>

<details>
  <summary><strong>🤝 Depois de terminar o desenvolvimento (opcional)</strong></summary><br/>

  Para sinalizar que o seu projeto está pronto para o _"Code Review"_, faça o seguinte:

  - Vá até a página **DO SEU** _Pull Request_, adicione a label de _"code-review"_ e marque seus colegas:

    - No menu à direita, clique no _link_ **"Labels"** e escolha a _label_ **code-review**;

    - No menu à direita, clique no _link_ **"Assignees"** e escolha **o seu usuário**;

    - No menu à direita, clique no _link_ **"Reviewers"** e digite `students`, selecione o time `tryber/students-sd-0x`.

  Caso tenha alguma dúvida, [aqui tem um video explicativo](https://vimeo.com/362189205).

</details>

<details>
  <summary><strong>🕵🏿 Revisando um pull request</strong></summary><br />

  Use o conteúdo sobre [Code Review](https://app.betrybe.com/course/real-life-engineer/code-review) para te ajudar a revisar os _Pull Requests_.

</details>

<details>
  <summary><strong>🎛 Linter</strong></summary><br />

  Usaremos o [NetAnalyzer](https://docs.microsoft.com/pt-br/dotnet/fundamentals/code-analysis/overview) para fazer a análise estática do seu código.

  Este projeto já vem com as dependências relacionadas ao _linter_ configuradas no arquivo `.csproj`.

  O analisador já é instalado pelo plugin da `Microsoft C#` no `VSCode`. Para isso, basta fazer o download do [plugin](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) e instalá-lo.
</details>

<details>
  <summary><strong>🛠 Testes</strong></summary><br />

  O .NET já possui sua própria plataforma de testes.
  
  Este projeto já vem configurado e com suas dependências.

  ### Executando todos os testes

  Para executar os testes com o .NET, execute o comando dentro do diretório do seu projeto `src/<project>` ou de seus testes `src/<project>.Test`!

  ```
  dotnet test
  ```

  ### Executando um teste específico

  Para executar um teste específico, basta executar o comando `dotnet test --filter Name~TestMethod1`.

  :warning: **Importante:** o comando irá executar testes cujo nome contém `TestMethod1`.

  :warning: **O avaliador automático não necessariamente avalia seu projeto na ordem em que os requisitos aparecem no readme. Isso acontece para deixar o processo de avaliação mais rápido. Então, não se assuste se isso acontecer, ok?**

  ### Outras opções para testes
  - Algumas opções que podem lhe ajudar são:
    -  `-?|-h|--help`: exibe a descrição completa de como utilizar o comando.
    -  `-t|--list-tests`: lista todos os testes, ao invés de executá-los.
    -  `-v|--verbosity <LEVEL>`: define o nível de detalhe na resposta dos testes.
      - `q | quiet`
      - `m | minimal`
      - `n | normal`
      - `d | detailed`
      - `diag | diagnostic`
      - Exemplo de uso: 
         ```
           dotnet test -v diag
         ```
         ou
         ```            
           dotnet test --verbosity=diagnostic
         ``` 
</details>

<details>
  <summary><strong>🗣 Nos dê feedbacks sobre o projeto!</strong></summary><br />

Ao finalizar e submeter o projeto, não se esqueça de avaliar sua experiência preenchendo o formulário. 
**Leva menos de 3 minutos!**

[FORMULÁRIO DE AVALIAÇÃO DE PROJETO](https://be-trybe.typeform.com/to/ZTeR4IbH#cohort_hidden=CH11&template=betrybe/acc-csharp-0x-exercises-my-wine)

</details>

<details>
  <summary><strong>🗂 Compartilhe seu portfólio!</strong></summary><br />

  Você sabia que o LinkedIn é a principal rede social profissional e que compartilhar aprendizados lá é muito importante para quem deseja construir uma carreira de sucesso? Compartilhe este projeto no seu LinkedIn, marque o perfil da Trybe (@trybe) e mostre para a sua rede toda a sua evolução.

</details>

# Requisitos

Uma empresa parceira da Trybe, a *My Wine*, está precisando de uma implementação em um de seus sistemas e precisamos da sua ajuda para realizar esse desenvolvimento. 

Essa empresa possui um clube de assinaturas digitais, em que as pessoas assinantes ganham diversos benefícios por mês, podendo ser mais ou menos, dependendo de seu tipo de assinatura. 

Sabendo disso, eles precisam realizar algumas notificações: algumas mensagens vão ser para todos, outras para pessoas clientes e também para pessoas clientes, porém com certe especificidade.

Para isso, é necessário lidar com o processo de autorização e permitir que as mensagens sejam acessíveis somente para quem pode realmente acessá-las.
## Antes de começar:
## Configure o Projeto

<details>
  <summary>Configurações em classe Program.cs </summary><br />

Primeiramente, é importante adicionar as configurações necessárias na classe `Program.cs`, como o comando para aceitar o procesos de autorização no projeto e também para adicionar a política de autorização baseada em `Claims`.

A *My Wine* possui pessoas clientes ao redor do país inteiro. Dessa forma, eles querem notificar somente pessoas de alguns estados do Brasil, que também possuam certo tipo de assinatura dentro da plataforma.

A regra é a seguinte:

- Criar Policy `CustomOffer`, que requer `Claim` de `StateOrProvince`, onde os estados permitidos são: `"Bahia", "Ceará", "Minas Gerais", "Roraima"`. Além disso, requer `Claim` de `CustomerType`, onde os tipos permitidos são: `"Lover", "Specialist"`.

Anota aí: Os tipos disponíveis atualmente na *My Wine* são:

- Basic

- Lover

- Specialist
  
</details>


## Adicione as propriedades na classe modelo

<details>
  <summary>Propriedades em User.cs</summary><br />

Para lidar com os dados das pessoas usuárias, vai ser utilizado um objeto modelo denominado `User`; dessa forma, devem ser adicionadas a esse objeto duas propriedades:

- State (Tipo: `string`. Vai armazenar valor do estado da pessoa usuária. Exemplo: `Bahia`)

- Type (Tipo: `string`. Vai armazenar valor do tipo de assinatura da pessoa usuária. Exemplo: `Lover`)
  
</details>

## Adicione `Claims` na criação do Token

<details>
  <summary>Adicionar configuração de Claim no Token em TokenGenerator.cs</summary><br />

A criação do Token já está sendo realizada, porém na propriedade `Subject` existe uma função sendo chamada `AddClaims()`, onde o objeto da pessoa usuária é passado como parâmetro. Dessa forma, é necessário adicionar as `Claims` de Estado e Tipo para esses valores serem armazenados no Token nesse momento de autenticação, pois no momento da autorização essas informações serão validadas.

</details>

## 1 - Criar Endpoint Anônimo

<details>
  <summary>Criar função MessageForEveryone()</summary><br />

No controlador `NotificationController`, adicionar a função `MessageForEveryone()`, que, por sua vez, não precisará de autorização.

- A rota dessa função deve ser: `NotifyEveryone`.

- Deve retornar uma string com valor `Se você tem mais de 18 anos, vamos assinar o My Wine?!`.

- Tipo Get de requisição HTTP.

</details>

<details>
  <summary>Criar Teste de Sucesso para Endpoint Anônimo </summary><br />

Na classe `TestAuthorizeMessageController`, adicionar a função `TestMessageForEveryoneSuccess()`. 

- Chamar função `RequestApi()` para realização da requisição `HTTP` passando a rota requerida como parâmetro. Nesse caso, a rota será: `Notification/NotifyEveryone`.

- Utilizar funções da biblioteca *FluentAssertions* para validar `StatusCode` retornado da requisição a `API`. Nesse caso de sucesso, o valor deve ser `System.Net.HttpStatusCode.Ok`. 

</details>

## 2 - Criar Endpoint com Autorização

<details>
  <summary>Criar função MessageForCustomers()</summary><br />

No controlador `NotificationController`, adicionar a função `MessageForCustomers()`, que, por sua vez, precisará de autorização.

- A rota dessa função deve ser: `NotifyCustomers`.

- Deve retornar uma string com valor `Avalie sua experiência com a My Wine!`.

- Tipo Get de requisição HTTP.

</details>


<details>
  <summary>Criar Teste de Sucesso para Endpoint com Autorização</summary><br />

Na classe `TestAuthorizeMessageController`, adicionar a função `TestMessageForCustomersSuccess()`. 

- Deve passar dois parâmetros utilizando o atributo `[InlineData]`: State e Type.

- Os parâmetros passados podem ser estados do Brasil e Tipos de Assinatura da *My Wine*.

- Deve montar objeto de `User` utilizando parâmetros passados.

- Chamar serviço de geração de Token passando objeto de `User`.

- Chamar função `RequestApi()` para realização da requisição `HTTP` passando a rota requerida como parâmetro e o Token retornado na função anterior. Nesse caso, a rota será: `Notification/NotifyCustomers`.

- Utilizar funções da biblioteca *FluentAssertions* para validar `StatusCode` retornado da requisição a `API`. Nesse caso de sucesso, o valor deve ser `System.Net.HttpStatusCode.OK`. 

</details>


<details>
  <summary> Criar Teste de Falha para Endpoint com Autorização </summary><br />

Na classe `TestAuthorizeMessageController`, adicionar a função `TestMessageForCustomersFail()`. 

- Deve passar um parâmetro utilizando o atributo `[InlineData]`: Token.

- O parâmetro passado deve ser uma string aleatório para simular um Token Inválido.

- Chamar função `RequestApi()` para realização da requisição `HTTP` passando a rota requerida como parâmetro e o Token passado como argumento. Nesse caso, a rota será: `Notification/NotifyCustomers`.

- Utilizar funções da biblioteca *FluentAssertions* para validar `StatusCode` retornado da requisição a `API`. Nesse caso de falha, o valor deve ser `System.Net.HttpStatusCode.Unauthorized`. 

</details>

## 3 - Criar Endpoint com Autorização baseada em `Claims`

<details>
  <summary>Criar função MessageForCustomOffer()</summary><br />

No controlador `NotificationController`, adicionar a função `MessageForCustomOffer()`, que, por sua vez, não precisará de autorização.

- A rota dessa função deve ser: `NotifyCustomCustomers`.

- Deve retornar uma string com valor `Aproveite 86% de desconto até sexta-feira em qualquer produto!`.

- Tipo Get de requisição HTTP.

- Autorização aplicando política `CustomOffer`, criada no item 1. 

</details>


<details>
  <summary>Criar Teste de Sucesso para Endpoint com Autorização baseada em `Claims`</summary><br />

Na classe `TestAuthorizeMessageController`, adicionar a função `TestMessageForCustomOfferSuccess()`. 

- Deve passar dois parâmetros utilizando o atributo `[InlineData]`: State e Type.

- Os parâmetros passados devem ser estados do Brasil e Tipos de Assinatura que façam parte da Policy criada: `CustomOffer`.

- Deve montar objeto de `User`, utilizando parâmetros passados.

- Chamar serviço de geração de Token passando objeto de `User`.

- Chamar função `RequestApi()` para realização da requisição `HTTP` passando a rota requerida como parâmetro e o Token retornado na função anterior. Nesse caso, a rota será: `Notification/NotifyCustomCustomers`.

- Utilizar funções da biblioteca *FluentAssertions* para validar `StatusCode` retornado da requisição a `API`. Nesse caso de sucesso, o valor deve ser `System.Net.HttpStatusCode.OK`. 

</details>


<details>
  <summary>Criar Teste de Falha para Endpoint com Autorização baseada em `Claims`</summary><br />

Na classe `TestAuthorizeMessageController`, adicionar a função `TestMessageForCustomOfferFail()`. 

- Deve passar dois parâmetros utilizando o atributo `[InlineData]`: State e Type.

- Os parâmetros passados não devem ser estados do Brasil e Tipos de Assinatura que façam parte da Policy criada: `CustomOffer`.

- Deve montar objeto de `User`, utilizando parâmetros passados.

- Chamar serviço de geração de Token passando objeto de `User`.

- Chamar função `RequestApi()` para realização da requisição `HTTP` passando a rota requerida como parâmetro e o Token retornado na função anterior. Nesse caso, a rota será: `Notification/NotifyCustomCustomers`.

- Utilizar funções da biblioteca *FluentAssertions* para validar `StatusCode` retornado da requisição a `API`. Nesse caso de falha, o acesso deve ser proibido, ou seja, o valor deve ser `System.Net.HttpStatusCode.Forbidden`. 

</details>
