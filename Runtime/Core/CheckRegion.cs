// // /*===============================================================================
// // Copyright (C) 2024 PhantomsXR Ltd. All Rights Reserved.
// //
// // This file is part of the Unity.Services.Core.
// //
// // The Infiniplay_visionOS cannot be copied, distributed, or made available to
// // third-parties for commercial purposes without written permission of PhantomsXR Ltd.
// //
// // Contact nswell@phantomsxr.com for licensing requests.
// // ===============================================================================*/

using System;
using System.Net.Http;
using Newtonsoft.Json;
using UnityEngine;

namespace Unity.Services.Core
{
    public class CheckRegion : MonoBehaviour
    {
        public static IpInfo IpInfo;
        public static bool IsChina;

        public static async System.Threading.Tasks.Task Checking()
        {
            using HttpClient tmp_Client = new HttpClient();
            string tmp_APIUrl = "http://ip-api.com/json";
            HttpResponseMessage tmp_Response = await tmp_Client.GetAsync(tmp_APIUrl);
            if (!tmp_Response.IsSuccessStatusCode) return;
            string tmp_JsonResponse = await tmp_Response.Content.ReadAsStringAsync();
            IpInfo = JsonConvert.DeserializeObject<IpInfo>(tmp_JsonResponse);
            IsChina = IpInfo.country == "China";
        }
    }

    public class IpInfo
    {
        public string country;
    }
}