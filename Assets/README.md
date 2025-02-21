Voici ton README mis à jour avec la modification demandée :  

---

# **Projet Unity - Télékinésie en Third Person**  

## **Description**  
Ce projet implémente une mécanique de télékinésie en **Third Person**, permettant au joueur de saisir et de lancer des objets dans les airs grâce à un système de **Rigidbody** et `addForce()`.  

Le projet met l'accent sur l'animation du personnage, la fluidité du mouvement et l'interaction réaliste avec les objets.  

## **Fonctionnalités principales**  

✅ **Télékinésie** : Saisissez un objet et projetez-le dans les airs.  

✅ **Animations réalistes** : Intégration d'animations via **Animator** et **Mixamo**.  

✅ **Déplacement fluide** :  
   * Marche et course (Shift pour courir).  
   * Accélération et décélération configurables.  

✅ **Interaction avec n'importe quel objet "Throwable"** :  
   * Ajoutez simplement le composant **Throwable** à un objet 3D.  
   * Possibilité de changer la couleur de l’objet (manuellement ou aléatoirement).  

✅ **Paramètres personnalisables dans le Player Controller** :  
   * Distance maximale de télékinésie.  
   * Force du lancer.  
   * Vitesse d'interpolation (Lerp).  
   * Debugging avancé : Activation de l'affichage du **Raycast** dans l’onglet **Scene**.  

## **Technologies utilisées**  
- **Moteur de jeu** : Unity 6  
- **Langage** : C#  
- **Animations** : Animator, Mixamo  
- **Physique** : Rigidbody, addForce(), Raycast  

## **Installation & Exécution**  

1. **Créer un projet Unity 6**  
   - Ouvrir **Unity Hub**  
   - Créer un nouveau projet **3D** avec Unity **6**  
   - Fermer Unity  

2. **Ajouter les fichiers**  
   - Copier le dossier **Assets** fourni dans le dossier du projet Unity créé.  

3. **Ouvrir le projet**  
   - Lancer Unity et ouvrir le projet.  

4. **Lancer la scène principale**  
   - Ouvrir `Assets/Scenes/MainScene.unity`  
   - Exécuter avec **Play**  

## **Auteur**  
👤 **Omar YASSINE**  
