using BelleBoucheeConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelleBoucheeConsoleApp.Services
{
    public class DisplayService : IDisplayService
    {
        public void mainMenu()
        {
            Console.WriteLine("Bienvenue au restaurant Belle bouchée");
            Console.WriteLine("");
            Console.WriteLine("Veuillez sélectionner une action");
            Console.WriteLine("");
            Console.WriteLine("1. Afficher le menu");
            Console.WriteLine("2. Ajouter un produit a la commande");
            Console.WriteLine("3. Supprimer un produit de la commande");
            Console.WriteLine("4. Payer la facture");
            Console.WriteLine("5. Afficher le solde de la facture");
            Console.WriteLine("6. Afficher l'inventaire ");
            Console.WriteLine("7. Aide ");
            Console.WriteLine("8. Quitter ");
        }

        public void productsMenu(List<Product> list)
        {
            Console.WriteLine("Liste des produits :");
            Console.WriteLine("");

            foreach (var product in list)
            {
                Console.WriteLine(product.Id + ". " + product.Name + "  || prix : " + product.Price );
            }
            returnText();
        }

        public void productsInventaire(List<Product> list)
        {
            Console.WriteLine("Liste des produits :");
            Console.WriteLine("");

            foreach (var product in list)
            {
                Console.WriteLine(product.Id + ". " + product.Name + "  || prix : " + product.Price + " || quantite : " + product.Quantity);
            }
            returnText();
        }

        public void addProductToOrder()
        {
            Console.WriteLine("Entree votre choix :");
        }

        public void addProductToOrderSuccess()
        {
            Console.WriteLine("*************** Produit ajouter avec success au panier *************");
        }

        public void addProductToOrderQuantity()
        {
            Console.WriteLine("Veuillez seisir la quantite :");
        }

        public void addProductToOrderDoesntExist()
        {
            Console.WriteLine("Le produit chosi n'exit pas !!!!!!!!!!!!!!!");
        }

        public void addProductToOrderQuantityDoesntExist()
        {
            Console.WriteLine("Le Quantite choisi n'exit pas !!!!!!!!!!!!!!!");
        }

        public void displayFacturation(List<OrderHasProducts> list , Order order)
        {
            Console.WriteLine("************* Facture Debut ***********");
            Console.WriteLine("");
            Console.WriteLine("ID    // Produit             // Quanite          // Pix ");
            foreach (var item in list)
            {
                Console.WriteLine(item.Product.Id + "   |  " + item.Product.Name + "  |  " + item.Quantity + "  |  " + item.Quantity * item.Product.Price);
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                                SubTotal : " + order.SubTotal);
            Console.WriteLine("                                TVQ : " + order.TVQ);
            Console.WriteLine("                                TPS : " + order.TPS);
            Console.WriteLine("____________________________________________________________");
            Console.WriteLine("                                Total : " + order.Total);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("************* Facture Fin ***********");
            returnText();

        }

        public void displaySelectedItems(List<OrderHasProducts> list)
        {
            Console.WriteLine("************* Selected Itmes Debut ***********");
            Console.WriteLine("");
            Console.WriteLine("ID    // Produit             // Quanite          // Pix ");
            foreach (var item in list)
            {
                Console.WriteLine(item.Product.Id + "   " + item.Product.Name + "   " + item.Quantity + "  " + item.Quantity * item.Product.Price);
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("************* Selected Items Fin ***********");
            returnText();

        }
        public void displayHelp()
        {
            Console.WriteLine("************* Help ***********");
            Console.WriteLine("");

            Console.WriteLine("Appyer sur le numero correspandant au produit pour faire votre choix");
            Console.WriteLine("La navigation entre les menu depands de vous choix");
            Console.WriteLine("vous pouvez a tout moment entree 00 pour revenir au menu principale");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("************* Help Fin ***********");
            returnText();

        }
        

        public void displayOrderTotal(Order order)
        {
            Console.WriteLine("************* Sold de la facture Debut ***********");
            Console.WriteLine("");
            Console.WriteLine(" Total a payer  : " + order.Total);
            Console.WriteLine("");
            Console.WriteLine("************* Sold de la facture Fin ***********");
            returnText();

        }

        public void payOrder()
        {
            Console.WriteLine("etes vous sure de bien proceeder au paiment de votre facture:");
            Console.WriteLine("1. Oui");
            Console.WriteLine("2. Non");

        }

        public void payOrderSuccess()
        {
            Console.WriteLine("votre paiement est passee avec success .");

        }

        public void payOrderFail()
        {
            Console.WriteLine("vous ne pouvez pas payee vous avez depasser le monatnt allouez 100 $ .");

        }


        private void returnText()
        {
            Console.WriteLine("");
            Console.WriteLine("00 Pour revenire au menu principale !!!!!");
        }

    }
}
