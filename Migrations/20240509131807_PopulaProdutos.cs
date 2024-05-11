using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopulaProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Produtos (Nome, Descricao, Preco, ImagemURL, Estoque, DataCadastro, CategoriaId)" +
                " Values ('CocaCola Diet', 'Refrigerante de Cola 350ml', 5.45, 'CocaCola.jpg', 50, GetDate(), 1)");

            mb.Sql("Insert into Produtos (Nome, Descricao, Preco, ImagemURL, Estoque, DataCadastro, CategoriaId)" +
                " Values ('Sanduiche', 'Sanduiche de Atum', 8.50, 'Sanduiche.jpg', 10, GetDate(), 2)");
            
            mb.Sql("Insert into Produtos (Nome, Descricao, Preco, ImagemURL, Estoque, DataCadastro, CategoriaId)" +
                " Values ('Pudim', 'Pudim pequeno', 6.75, 'Pudim.jpg', 20, GetDate(), 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Produtos");
        }
    }
}
