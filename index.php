<?php
require_once "./DataManager.class.php";
/***************************************
 * Contraintes REST (requêtes HTTP) :
 * GET pour lire des données
 * POST pour créer des données
 * PUT pour  mettre à jour des données
 * DELETE pout supprimer des données
 *****************************************/
$request_method = $_SERVER["REQUEST_METHOD"];

switch ($request_method) {

    case 'GET':

        try {

            if (!empty($_GET['request'])) {

                // On splite la variable $_GET avec explode() en la sécurisant grâce à filter_var() avec un filtre spécifique : FILTER_SANITIZE_URL 
                // qui supprime tous les caractères sauf les lettres, chiffres et $-_.+!*'(),{}|\\^~[]`<>#%";/?:@&=.
                $url = explode("/", filter_var($_GET['request'], FILTER_SANITIZE_URL));
                switch ($url[0]) {

                    case "books":

                        // Point de sortie #1 
                        $books = DataManager::getBooks();
                        if (count($books) <> 0) sendJSON($books);
                        break;

                    case "book":

                        // Point de sortie #2 
                        if (!empty($url[1])) sendJSON(DataManager::getBookById($url[1]));
                        break;

                    default:
                        throw new Exception("404 Not Found");
                }
            } else {
                throw new Exception("400 Bad Request");
            }
        } catch (Exception $e) {
            $erreur = [
                "message" => $e->getMessage(),
                "code" => $e->getCode()
            ];
            print_r($erreur);
        }
        break;

    default:
        header("HTTP/1.0 405 Method Not Allowed");
        break;
}

function sendJSON($data)
{
    header("Access-Control-Allow-Origin: *");
    header("Content-Type: application/json");
    echo json_encode($data, JSON_UNESCAPED_UNICODE);
}
