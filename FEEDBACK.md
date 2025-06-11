# Feedback - Avaliação Geral

## Front End

### Navegação
  * Pontos positivos:
    - Projeto MVC implementado com views e controllers funcionais para produtos, categorias e autenticação.

  * Pontos negativos:
    - Nenhum.

### Design
  - Interface clara e simples, funcional para o gerenciamento de dados.

### Funcionalidade
  * Pontos positivos:
    - CRUD completo de produtos e categorias implementado na API e no MVC.
    - Identity implementado no MVC com autenticação funcional.
    - Arquitetura composta por três camadas adequadas: API, MVC e Core.
    - Migrations automáticas e seed de dados implementados via SQLite.
    - Modelagem de entidades está bem estruturada e aderente ao escopo.

  * Pontos negativos:
    - API não possui autenticação via Identity.
    - Não há criação de usuário nem de vendedor com ID compartilhado na API e no MVC.
    - Produtos não estão associados ao usuário logado.
    - Produto pode ser alterado por qualquer vendedor, o que é uma falha de segurança.
    - O seed de dados está acoplado à configuração do contexto EF, o que é uma má prática e pode causar problemas de desempenho e manutenção.

## Back End

### Arquitetura
  * Pontos positivos:
    - Separação clara entre API, MVC e Core.
    - Estrutura de projetos compatível com boas práticas para aplicações modulares.

  * Pontos negativos:
    - Seed de dados acoplado ao `DbContext`, em vez de ser disparado via `Program.cs`.

### Funcionalidade
  * Pontos positivos:
    - CRUD, autenticação básica e organização modular presentes.

  * Pontos negativos:
    - Identidade não implementada na API.
    - Falta de vinculação entre usuário e produto, e ausência de controle de propriedade.

### Modelagem
  * Pontos positivos:
    - Entidades bem desenhadas e aderentes ao domínio proposto.

  * Pontos negativos:
    - Entidade `Vendedor` está presente mas não vinculada ao usuário do Identity.

## Projeto

### Organização
  * Pontos positivos:
    - Boa separação de pastas e arquivos por projeto.
    - Uso de `src`, arquivos `.sln` organizados, e documentação presente.

  * Pontos negativos:
    - Inicialização de seed no contexto em vez do `Program.cs`.

### Documentação
  * Pontos positivos:
    - `README.md` e `FEEDBACK.md` presentes e com informações úteis.
    - Swagger disponível na API.

### Instalação
  * Pontos positivos:
    - SQLite, migrations automáticas e execução simples.

  * Pontos negativos:
    - Nenhum.

---

# 📊 Matriz de Avaliação de Projetos

| **Critério**                   | **Peso** | **Nota** | **Resultado Ponderado**                  |
|-------------------------------|----------|----------|------------------------------------------|
| **Funcionalidade**            | 30%      | 7        | 2,1                                      |
| **Qualidade do Código**       | 20%      | 7        | 1,4                                      |
| **Eficiência e Desempenho**   | 20%      | 8        | 1,6                                      |
| **Inovação e Diferenciais**   | 10%      | 7        | 0,7                                      |
| **Documentação e Organização**| 10%      | 8        | 0,8                                      |
| **Resolução de Feedbacks**    | 10%      | 7        | 0,7                                      |
| **Total**                     | 100%     | -        | **7,3**                                  |

## 🎯 **Nota Final: 7,3 / 10**
