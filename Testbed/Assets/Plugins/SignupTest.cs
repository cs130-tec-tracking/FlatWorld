using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Zenject;
using Newtonsoft.Json;
using Stage.App;
using Stage.App.Services;
using Stage.App.Models;

namespace Stage
{
    public class SignupTest : MonoBehaviour
    {
        SignupService _signupService;
       // AuthorizationService _authorizationService;

        [Inject]
        public void Construct(
            SignupService signupService
            //AuthorizationService authorizationService
        )
        {
            _signupService = signupService;
           // _authorizationService = authorizationService;
        }

        void Start()
        {
            _signupService.model.name = new SignupName()
            {
                firstName = "Blake",
                lastName = "Nussey"
            };
            _signupService.model.email = "joey1@stage.co";
            _signupService.model.password = "2134";

           // Register();
            
        }
/*
        public void Register()
        {
            _authorizationService.Register(_signupService.RegisterModel())
                                .Subscribe(
                                    success =>
                                            {
                                                Debug.Log("Authorization Register Success " + success);
                                                RegisterSuccess();
                                            },
                                    error =>
                                    {
                                        string errorMessage = ApiUtils.ParseErrorMessage(error);
                                        Debug.Log("Authorization Register Error " + errorMessage);
                                    }
              );
        }

        public void RegisterSuccess()
        {
            _authorizationService.Authorize(_signupService.AuthorizeModel())
                                .Subscribe(
                                    success =>
                                    {
                                        Debug.Log("Authorization Authorize Success - New user account authorised " + success);
                                        // Carry on
                                    },
                                    error =>
                                    {
                                        Debug.Log("Authorization Authorize Error " + error);
                                    }
                                );
        }
*/
    }
}
