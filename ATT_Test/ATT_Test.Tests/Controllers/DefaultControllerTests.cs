using Microsoft.VisualStudio.TestTools.UnitTesting;
using ATT_Test.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATT_Test.Models;

namespace ATT_Test.Controllers.Tests
{
    [TestClass()]
    public class DefaultControllerTests
    {
        [TestMethod()]
        public async void GetTest()
        {
            var test = GetIssues();
            var controller = new DefaultController(test);
            var result = await controller.Get() as List<Issues>;
            Assert.AreEqual(test.Count, result.Count);

        }
        private List<Issues> GetIssues()
        {
            var testProducts = new List<Issues>();
            testProducts.Add(new Issues { title= "Update handling of cells with unknown states",Repository_FullName=null,Comments=0,Commentsurl="https://api.github.com/repos/att/rcloud/issues/2536/comments",Body="Make sure that result div of running cells is not cleaned up on edit so the output is displayed.\r\nAlso use 'unknown' state as the final state for such cells, not 'Ready'.\r\n\r\nFIX #2529",url="https://api.github.com/repos/att/rcloud/issues/2536"});
            testProducts.Add(new Issues { title = "Highlight button using icon color.", Repository_FullName = null, Comments = 1, Commentsurl = "https://api.github.com/repos/att/rcloud/issues/2535/comments", Body = "It took much longer than I thought. I am also not happy with how it works/looks as the animation is affected by updates to the page while a notebook is executed. I wonder if we should consider using progress spinner instead of animating the color. This would be consistent with the way the progress is indicated on notebook cells when they are running. @gordonwoodhull what do you think?\r\n\r\nRegarding implementation, it simply animates the color of the 'play' icon.\r\n\r\nI tried using jquery-ui animations so the highlighting style would be specified in CSS, but for some reason animations submitted by jquery-ui are not executed. Are you aware of that? Are they disabled on purpose or is this a bug?\r\n\r\nFIX #2530", url = "https://api.github.com/repos/att/rcloud/issues/2535" });
            testProducts.Add(new Issues { title = "editing a running cell causes its output to disappear", Repository_FullName = null, Comments = 0, Commentsurl = "https://api.github.com/repos/att/rcloud/issues/2529/comments", Body = "Create a slow cell (for example with a `Sys.sleep` in it). Run it, and then start editing the code.\r\n\r\nOnce autosave kicks in (and status turns to spinning question mark), the output is irretrievably lost and it isn't clear what's going on.\r\n\r\nStrangely, it doesn't seem like output is lost if a non-running cell is run, so I'm not sure what's happening here. (It could be intentional, but if so it's a bad idea.)", url = "https://api.github.com/repos/att/rcloud/issues/2529" });
            testProducts.Add(new Issues { title = "Autoscroll output in notebook pane when cell is executed.", Repository_FullName = null, Comments = 7, Commentsurl = "https://api.github.com/repos/att/rcloud/issues/2526/comments", Body = "The scroll will only be performed if the executed cell's input is visible and output would not fit into displayed area in the notebook pane.\r\n\r\nFIX #2222 \r\n\r\nI also investigated what would be involved in applying different autoscroll strategies depending on:\r\n* if 'Run All' was selected\r\n* if the prompt cell was visible when bulk of cells got executed.\r\nand in such case autoscroll to cell outputs despite visibiliy of their source.\r\n\r\nSupporting the above would require a bit more work, as the view would need to be aware of the state of the view when execution got triggered and use it when results are rendered to apply autoscrolling. \r\n\r\nImplementing these however do have some implications on user experience - e.g. when a user runs all cells, the notebook pane would scroll until all cells got processed, this may not necessarily be user-friendly if there are a few htmlwidgets in the notebook. Also we could potentially want to disable autoscrolling during execution of all cells, if user manually scrolls the notebook pane. \r\n\r\n@gordonwoodhull, what do you think? Should I have a look at this?", url = "https://api.github.com/repos/att/rcloud/issues/2526" });

            return testProducts;
        }
    }
}