# Feedback - Avaliação Geral

## Front End
### Navegação
  * Pontos positivos:
    - O projeto possui views e rotas definidas para as funcionalidades, seguindo o padrão do ASP.NET Core MVC. A navegação entre as principais operações de produtos e categorias está implementada.

### Design
    - Será avaliado na entrega final

### Funcionalidade
  * Pontos positivos:
    - As funcionalidades de cadastro, edição, visualização e exclusão de produtos e categorias estão implementadas no front-end, conforme os casos de uso esperados para uma loja virtual.

## Back End
### Arquitetura
  * Pontos positivos:
    - O projeto está dividido em múltiplos projetos: MVC, API e Core, o que é adequado e segue boas práticas para separação de responsabilidades.
    - A quantidade de projetos é ideal para o escopo proposto.

  * Pontos negativos:
    - Há duplicação significativa de código entre as controllers do MVC e da API, devido à ausência de uma implementação de serviços centralizados para abstração e reaproveitamento de lógica de negócio.
    - Recomenda-se evitar duplicação e criar serviços compartilhados para lógica comum entre MVC e API.
    - Não há uso de padrões avançados desnecessários, o que está correto para o contexto.

### Funcionalidade
  * Pontos positivos:
    - As operações CRUD para produtos e categorias estão implementadas tanto na API quanto no MVC.
    - O projeto utiliza Entity Framework Core com SQLite, conforme especificação.

  * Pontos negativos:
    - Não é realizada a criação do registro da entidade "Vendedor" no momento do registro do usuário via Identity, nem na camada MVC, nem na API, contrariando o requisito do escopo.

### Modelagem
  * Pontos positivos:
    - A modelagem das entidades é simples e direta, adequada para o contexto de uma loja virtual.

  * Pontos negativos:
    - Faltam implementações necessárias relacionadas à criação automática do vendedor no fluxo de registro.

## Projeto
### Organização
  * Pontos positivos:
    - O projeto está organizado em múltiplos projetos dentro da pasta principal, separando claramente MVC, API e Core.
    - O arquivo de solução (`.sln`) está presente na raiz da pasta principal.
    - O arquivo `FEEDBACK.md` está presente.

### Documentação
  * Pontos positivos:
    - O repositório possui um arquivo `README.md` bem documentado, com informações do projeto e instruções de execução.
    - O arquivo `FEEDBACK.md` está presente.
    - A documentação da API via Swagger está presente.

### Instalação
  * Pontos positivos:
    - O projeto utiliza SQLite como banco de dados, facilitando a execução local.

  * Pontos negativos:
    - Não há implementação de seed de dados e migrations automáticas ao iniciar a aplicação, o que dificulta o uso imediato do sistema.
