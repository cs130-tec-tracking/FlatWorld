using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UniRx;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using Zenject;
//using Stage.App.Core;
using Stage.App.Models;
//using Stage.App.Utils;
//using StageMe.Common.Web.Models.Requests.Asset;
//using StageMe.Common.Web.Models.Values;

//using Stage.Api.Sdk.V1.Models.Authorizations;
//using Stage.Api.Sdk.V1.Enumerators.Authorizations;

namespace Stage.App.Services
{

    public class SignupService
    {

        public Signup model { get; set; }

        [Inject]
        public void Construct(
        )
        {
            initSignup();
        }

        public void initSignup()
        {
            model = new Signup()
            {
                name = new SignupName()
                {
                    firstName = "",
                    lastName = ""
                },
                email = "",
                password = ""
            };
        }
/*
        public RegisterStage RegisterModel()
        {
            return new RegisterStage()
            {
                identity = new RegisterStageIdentity()
                {
                    email = model.email,
                    password = model.password,
                    firstName = model.name.firstName,
                    lastName = model.name.lastName
                }
            };
        }

        public AuthorizationStage AuthorizeModel()
        {
            return new AuthorizationStage()
            {
                identity = new AuthorizationStageIdentity()
                {
                    email = model.email,
                    password = model.password
                }
            };
        }
*/
    }

}

