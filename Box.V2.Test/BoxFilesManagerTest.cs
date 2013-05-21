﻿using Box.V2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Box.V2.Test
{
    [TestClass]
    public class BoxFilesManagerTest : BoxResourceManagerTest
    {
        [TestMethod]
        public async Task GetFileInfo_ValidResponse_ValidFolder()
        {
            string responseString = "{ \"type\": \"file\", \"id\": \"5000948880\", \"sequence_id\": \"3\", \"etag\": \"3\", \"sha1\": \"134b65991ed521fcfe4724b7d814ab8ded5185dc\", \"name\": \"tigers.jpeg\", \"description\": \"a picture of tigers\", \"size\": 629644, \"path_collection\": { \"total_count\": 2, \"entries\": [ { \"type\": \"folder\", \"id\": \"0\", \"sequence_id\": null, \"etag\": null, \"name\": \"All Files\" }, { \"type\": \"folder\", \"id\": \"11446498\", \"sequence_id\": \"1\", \"etag\": \"1\", \"name\": \"Pictures\" } ] }, \"created_at\": \"2012-12-12T10:55:30-08:00\", \"modified_at\": \"2012-12-12T11:04:26-08:00\", \"trashed_at\": null, \"purged_at\": null, \"content_created_at\": \"2013-02-04T16:57:52-08:00\", \"content_modified_at\": \"2013-02-04T16:57:52-08:00\", \"created_by\": { \"type\": \"user\", \"id\": \"17738362\", \"name\": \"sean rose\", \"login\": \"sean@box.com\" }, \"modified_by\": { \"type\": \"user\", \"id\": \"17738362\", \"name\": \"sean rose\", \"login\": \"sean@box.com\" }, \"owned_by\": { \"type\": \"user\", \"id\": \"17738362\", \"name\": \"sean rose\", \"login\": \"sean@box.com\" }, \"shared_link\": { \"url\": \"https://www.box.com/s/rh935iit6ewrmw0unyul\", \"download_url\": \"https://www.box.com/shared/static/rh935iit6ewrmw0unyul.jpeg\", \"vanity_url\": null, \"is_password_enabled\": false, \"unshared_at\": null, \"download_count\": 0, \"preview_count\": 0, \"access\": \"open\", \"permissions\": { \"can_download\": true, \"can_preview\": true } }, \"parent\": { \"type\": \"folder\", \"id\": \"11446498\", \"sequence_id\": \"1\", \"etag\": \"1\", \"name\": \"Pictures\" }, \"item_status\": \"active\" }";
                _handler.Setup(h => h.ExecuteAsync<Folder>(It.IsAny<IBoxRequest>()))
                    .Returns(Task.FromResult<IBoxResponse<Folder>>(new BoxResponse<Folder>() {
                        Status = ResponseStatus.Success,
                        ContentString = responseString
                    }));

            BoxRequest request = new BoxRequest(_baseUri, "folder");
        }
    }
}