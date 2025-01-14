const Article = require('mongoose').model('Article');
const Category = require('mongoose').model('Category');
const Tag = require('mongoose').model('Tag');
const initializeTags = require('./../models/Tag');

module.exports = {
    createGet: (req, res) => {

        if(!req.isAuthenticated()){
            let returnUrl = '/article/create';
            req.session.returnUrl = returnUrl;
            res.redirect('/user/login');
            return
        }
        Category.find({}).then(categories => {
            res.render('article/create', {categories: categories});
        });
    },
    createPost: (req, res) => {
        let articleArgs = req.body;

        let errorMsg = '';
        if(!req.isAuthenticated()){
            errorMsg = 'You should be logged in to make articles!'
        } else if (!articleArgs.title){
            errorMsg = 'Invalid title!';
        } else if (!articleArgs.content){
            errorMsg = 'Invalid content!';
        }

        if (errorMsg) {
            res.render('article/create', {error: errorMsg});
            return;
        }

        articleArgs.author = req.user.id;
        articleArgs.tags=[];
        Article.create(articleArgs).then(article => {
            let tagNames = articleArgs.tagNames.split(/\s+|,/).filter(tag => {return tag});
            initializeTags(tagNames,article.id);
            article.prepareInsert();
            res.redirect('/');
            })
    },
    details: (req, res) => {
        let id = req.params.id;

        Article.findById(id).populate('author').then(article => {
            let isUserAuthorized = req.user;

            if(!isUserAuthorized){
                article.isUserAuthorized = isUserAuthorized;
                res.render('article/details', article)
            }else{
                req.user.isInRole('Admin').then(isAdmin =>{
                    if(!isAdmin && !req.user.isAuthor(article)){
                        article.isUserAuthorized = false;
                        res.render('article/details', article);
                    }else{
                        isUserAuthorized = true;
                        article.isUserAuthorized = isUserAuthorized;
                        res.render('article/details', article)
                    }

                });
            }
        })
    },
    editGet: (req, res) => {


        let id = req.params.id;

        if(!req.isAuthenticated()){
            let returnUrl = `/article/edit/${id}`;
            req.session.returnUrl= returnUrl;

            res.redirect('/user/login');
            return;

        }
        Article.findById(id).populate('tags').then(article => {

            req.user.isInRole('Admin').then(isAdmin =>{
                if(!isAdmin && !req.user.isAuthor(article)){
                    res.redirect('/');
                }else{

                    Category.find({}).then(categories => {
                        article.categories = categories;
                        res.render('article/edit', article);
                    });
                }
            });
        });
        Category.find({}).then(categories => {
            article.categories = categories;
            article.tagNames =article.tags.map(tag => {return tag.name});
            res.render('article/edit', article);
        });
    },
    editPost: (req, res) => {
        let id = req.params.id;

        let articleArgs = req.body;

        let errorMsg = '';
        if(!articleArgs.title){
            errorMsg = 'Article title cannot be empty!';

        } else if (!articleArgs.content){
            errorMsg = 'Article content cannot be empty!';
        }

        if(errorMsg){
            res.render('article/edit', {error: errorMsg})
        }else {
            Article.findById(id).populate('category').then( article => {
                if(article.category.id !== articleArgs.category){
                    article.category.articles.remove(article.id);
                    article.category.save();
                }
                article.category = articleArgs.category;
                article.title = articleArgs.title;
                article.content = articleArgs.content;
                article.save((err) => {
                    if(err){
                        console.log(err.message);
                    }

                    Category.findById(article.category).then(category => {
                        if(category.articles.indexOf(article.id) === -1){
                            category.articles.push(article.id);
                            category.save();
                        }
                        res.redirect(`/article/details/${id}`);
                    })
                })

            })
        }
    },
    deleteGet: (req, res) => {
        let id = req.params.id;

        if(!req.isAuthenticated()) {
            let returnUrl = `/article/delete/${id}`;
            req.session.returnUrl = returnUrl;

            res.redirect('/user/login');
            return;
        }
        Article.findById(id).then(article => {

            let currentUser = req.user;

            currentUser.isInRole('Admin').then(isAdmin =>{
                if(!isAdmin && !currentUser.isAuthor(article)){
                    res.redirect('/');
                }else{
                    res.render('article/delete');
                }
            });
            res.render('article/delete', article);
        });
    },
    deletePost: (req, res) => {
        let id = req.params.id;
        if(!req.isAuthenticated()) {
            let returnUrl = `/article/delete/${id}`;
            req.session.returnUrl = returnUrl;

            res.redirect('/user/login');
            return;
        }
        Article.findOneAndRemove({_id:id}).populate('author').then(article => {
            article.prepareDelete();
            res.redirect('/');
        });
    }
};