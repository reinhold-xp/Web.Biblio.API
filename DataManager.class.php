<?php
require_once "./DataConnexion.class.php";

const PICS_FOLDER = "https://www.books.reinhold-info.com/public/images/";

class DataManager extends DataConnexion
{
    public static function getBooks()
    {
        $pdo = self::getBdd();
        $req = ("SELECT livres.id, livres.titre, livres.nbPages, livres.image, livres.resume, auteurs.nom AS 'auteur' 
                FROM livres 
                INNER JOIN auteurs ON livres.id_auteur = auteurs.id");

        $stmt = $pdo->prepare($req);
        $stmt->execute();

        $books = $stmt->fetchAll(PDO::FETCH_ASSOC);
        for ($i = 0; $i < count($books); $i++) {
            $books[$i]['image'] = PICS_FOLDER . $books[$i]['image'];
        }

        $stmt->closeCursor();
        return $books;
    }

    public static function getBookById($id)
    {
        $pdo = self::getBdd();
        $req = ("SELECT livres.id, livres.titre, livres.nbPages, livres.image, livres.resume, auteurs.nom AS 'auteur' 
                FROM livres 
                INNER JOIN auteurs ON livres.id_auteur = auteurs.id
                WHERE livres.id = :id");

        $stmt = $pdo->prepare($req);
        $stmt->bindValue(":id", $id, PDO::PARAM_INT);
        $stmt->execute();

        $book = $stmt->fetch(PDO::FETCH_ASSOC);
        if (!empty($book)) $book['image'] = PICS_FOLDER . $book['image'];
        else throw new Exception("400 Bad Request");

        $stmt->closeCursor();
        return $book;
    }
}
