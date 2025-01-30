using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

public class GoogleCloudAuth
{
    //public static GoogleCredential CreateGoogleCredential()
    //{
    //    Read environment variables
    //    string audience = Environment.GetEnvironmentVariable("GOOGLE_WORKLOADIDENTITY_AUDIENCE");
    //    string serviceAccount = Environment.GetEnvironmentVariable("GOOGLE_WORKLOADIDENTITY_SERVICEACCOUNT");
    //    string region = Environment.GetEnvironmentVariable("AWS_DEFAULT_REGION");

    //    if (string.IsNullOrEmpty(audience) || string.IsNullOrEmpty(serviceAccount) || string.IsNullOrEmpty(region))
    //    {
    //        throw new InvalidOperationException("Required environment variables are not set.");
    //    }

    //    Configure the credential source
    //    var credentialSource = new Dictionary<string, object>
    //    {
    //        { "environment_id", "aws1" },
    //        { "regional_cred_verification_url", $"https://sts.{region}.amazonaws.com?Action=GetCallerIdentity&Version=2011-06-15" }
    //    };

    //    Build the GoogleCredential
    //    return GoogleCredential.FromJson(JsonConvert.SerializeObject(new
    //    {
    //        type = "external_account",
    //        audience = audience,
    //        subject_token_type = "urn:ietf:params:aws:token-type:aws4_request",
    //        token_url = "https://sts.googleapis.com/v1/token",
    //        credential_source = credentialSource,
    //        service_account_impersonation_url = $"https://iamcredentials.googleapis.com/v1/projects/-/serviceAccounts/{serviceAccount}:generateAccessToken"
    //    }));
    //}

    //private static GoogleCredential AuthenticateUsingEnvironmentVariables()
    //{
    //    // Read required environment variables
    //    var audience = Environment.GetEnvironmentVariable("GOOGLE_WORKLOADIDENTITY_AUDIENCE");
    //    var serviceAccount = Environment.GetEnvironmentVariable("GOOGLE_WORKLOADIDENTITY_SERVICEACCOUNT");
    //    var region = Environment.GetEnvironmentVariable("AWS_DEFAULT_REGION");

    //    if (string.IsNullOrEmpty(audience) || string.IsNullOrEmpty(serviceAccount))
    //    {
    //        throw new InvalidOperationException("GOOGLE_WORKLOADIDENTITY_AUDIENCE and GOOGLE_WORKLOADIDENTITY_SERVICEACCOUNT must be set.");
    //    }

    //    // Initialize External Account Credentials
    //    var externalAccountCredential = ExternalAccountCredential.FromJsonParameters(new ExternalAccountCredential.Initializer
    //    {
    //        Audience = audience,
    //        TokenUrl = "https://sts.googleapis.com/v1/token",
    //        SubjectTokenType = "urn:ietf:params:aws:token-type:aws4_request",
    //        ServiceAccountImpersonationUrl = $"https://iamcredentials.googleapis.com/v1/projects/-/serviceAccounts/{serviceAccount}:generateAccessToken",
    //        CredentialSource = new Dictionary<string, object>
    //        {
    //            { "environment_id", "aws1" },
    //            { "regional_cred_verification_url", $"https://sts.{GetAwsRegion()}.amazonaws.com?Action=GetCallerIdentity&Version=2011-06-15" }
    //        }
    //    });

    //    return GoogleCredential.FromExternalAccount(externalAccountCredential);
    //}

    //private static string GetAwsRegion()
    //{
    //    // Get AWS region from metadata service
    //    using (var httpClient = new HttpClient())
    //    {
    //        return httpClient.GetStringAsync("http://169.254.169.254/latest/meta-data/placement/availability-zone").Result.TrimEnd('a', 'b', 'c', 'd');
    //    }
    //}
}